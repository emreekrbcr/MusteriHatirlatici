using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Entities.Concrete;
using Entities.Dtos;
using UI.WinForm.FrontEndExceptions;

namespace UI.WinForm
{
    public partial class Form1 : Form
    {
        private void
            HandleException(Action action) //Merkezi hata yakalama fonksiyonu, bu sayede front end'de sürekli try-catch yazmamıza gerek kalmayacak
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                MessageBox.Show(exception.Message);
            }
        }

        private void LoadDataGridView<T>(List<T> list)
        {
            dataGridView1.Columns.Clear(); //Aşağıda Kalan Gün sütunu eklemesi yaptığım için eğer her datagridview değiştiğinde sütunları temizlemezsem hata veriyor
            dataGridView1.DataSource = list;
            dataGridView1.RowHeadersWidth = 30; //Baştaki girintinin ayarı

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = true; //Önce hepsininin görünürlüğünü açsın, aşağıdaki durumlara göre görünürlük şekillenecek 
            }

            if (typeof(T) == typeof(Customer))
            {
                dataGridView1.Columns[0].Visible = false; //id'lerin olduğu satır gözükmesin diye

                dataGridView1.Columns[1].HeaderCell.Value = "İsim"; //Sütun isimlerinde Türkçe karakter olanlara bir ayar çekiyoruz
                dataGridView1.Columns[2].Width = 150; //Telefon
                dataGridView1.Columns[4].HeaderCell.Value = "Açıklama";
                dataGridView1.Columns[4].Width = 275;

                gbxOperation.Enabled = false;
                gbxCustomer.Enabled = true;
            }

            if (typeof(T) == typeof(Operation))
            {

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;

                dataGridView1.Columns[2].HeaderCell.Value = "İşlem";
                dataGridView1.Columns[2].Width = 340;
                dataGridView1.Columns[4].HeaderCell.Value = "Ödenen";
                dataGridView1.Columns[5].HeaderCell.Value = "Borç";
                dataGridView1.Columns[6].HeaderCell.Value = "İşlem Tarihi";
                dataGridView1.Columns[7].HeaderCell.Value = "Hatırlatma Tarihi";

                dataGridView1.Columns.Add("KalanGun", "Kalan Gün");
                dataGridView1.Columns["KalanGun"].Width = 65;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["KalanGun"].Value = Convert.ToInt32((Convert.ToDateTime(row.Cells[7].Value) - DateTime.Today).TotalDays);
                }

                dataGridView1.Columns[3].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[4].DefaultCellStyle.Format = "N2";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";

                gbxOperation.Enabled = true;
                gbxCustomer.Enabled = false;
            }

            if (typeof(T) == typeof(ReminderDto))
            {
                dataGridView1.Columns[0].HeaderCell.Value = "İsim";
                dataGridView1.Columns[0].Width = 160;
                dataGridView1.Columns[1].HeaderCell.Value = "Telefon";
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].HeaderCell.Value = "Adres";
                dataGridView1.Columns[3].HeaderCell.Value = "Açıklama";
                dataGridView1.Columns[4].HeaderCell.Value = "İşlem";
                dataGridView1.Columns[5].HeaderCell.Value = "Borç";
                dataGridView1.Columns[5].Width = 90;
                dataGridView1.Columns[6].HeaderCell.Value = "Kalan Gün";
                dataGridView1.Columns[6].Width = 65;

                dataGridView1.Columns[5].DefaultCellStyle.Format = "N2";
                gbxCustomer.Enabled = false;
                gbxOperation.Enabled = false;
            }

            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
            lblTotal.Text = dataGridView1.RowCount.ToString();
        }

        private Customer SetCustomer(Customer customer)
        {
            //Insert için hatalar Business Logic'te yazıldı
            customer.Isim = tbCustomerName.Text;
            customer.Telefon = tbTelNo.Text;
            customer.Adres = tbAdress.Text;
            customer.Aciklama = tbInfo.Text;
            return customer;
        }

        private Customer SetCustomerForUpdate(Customer customer)
        {
            customer.MusteriID = GetCustomerIDFromDgw();
            SetCustomer(customer);
            return customer;
        }

        private int GetCustomerIDFromDgw()
        {
            //Delete'de şöyle bir durum var dgw'de silmek için seçili bir müşteri yoksa butonun event'ında try-catch bile kullansam
            //try-catch'e düşmeden nesneye referans atanması işleminde null reference hatası oluşuyor
            //o yüzden orada yakalanması için buradan hata fırlatılması lazım
            if (dataGridView1.CurrentCell != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); //Resharper burada  Null Reference olabileceğine dair uyarıda bulunuyor, baştan dinlemek lazım :)
                return id;
            }

            throw new DgwItemNotSelectedException("Lütfen ilgili müşteriyi tablodan seçiniz");
        }

        private Operation SetOperation(Operation operation)
        {
            tbCost.Text = tbCost.Text.Replace(".", ","); //Kullanıcı . girerse onda da virgül gibi davransın diye
            tbPaid.Text = tbPaid.Text.Replace(".", ",");

            operation.MusteriID = _currentCustomerID;
            operation.Islem = tbOperation.Text;
            operation.Tutar = (tbCost.Text.Length != 0) ? Convert.ToDouble(tbCost.Text) : 0; //Boşşa varsayılan değeri 0
            operation.Odenen = (tbPaid.Text.Length != 0) ? Convert.ToDouble(tbPaid.Text) : 0; //Boşşa varsayılan değeri 0
            operation.IslemTarihi = dtpOperationDate.Value.Date;
            operation.HatirlatmaTarihi = dtpReminderDate.Value.Date;
            return operation;
        }

        private Operation SetOperationForUpdate(Operation operation)
        {
            operation.IslemID = GetOperationIDFromDgw();
            SetOperation(operation);
            return operation;
        }

        private int GetOperationIDFromDgw()
        {
            if (dataGridView1.CurrentCell != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                return id;
            }

            throw new DgwItemNotSelectedException("Lütfen ilgili işlemi tablodan seçiniz");
        }

        private int GetCurrentCell()
        {
            if (dataGridView1.CurrentCell != null)
            {
                return dataGridView1.CurrentCell.RowIndex;
            }

            throw new DgwItemNotSelectedException("Lütfen ilgili satırı tablodan seçiniz");
        }

        private int GetRemainingDay()
        {
            if (cbReminder.Text.Length != 0)
            {
                return Convert.ToInt32(cbReminder.Text);
            }

            throw new ParameterNullException("Kalan gün seçili değil(Programla alakalı)");
        }

        private void SetTBHover()
        {
            string text = dataGridView1.Rows[_rowIndex].Cells[_columnIndex].Value.ToString();
            _enlarger.Width = _dgwCellLoc.Size.Width;
            _enlarger.tbHover.Text = text;
            _enlarger.Location = new Point(_cellX, _cellY); //Çıkacak olan textbox'un location'u ilgili hücrenin hemen altı oldu
            _enlarger.Visible = true;
        }

        private void ClearAllBoxes()
        {
            tbOperation.Text = "";
            tbCost.Text = "";
            tbPaid.Text = "";
            dtpOperationDate.Value = DateTime.Now;
            dtpReminderDate.Value = DateTime.Now;

            if (!(gbxOperation.Enabled && gbxCustomer.Enabled == false))
            {
                tbCustomerName.Text = "";
                tbTelNo.Text = "";
                tbAdress.Text = "";
                tbInfo.Text = "";
            }
        }

        private void FillTextBoxes()
        {
            HandleException(() =>
            {
                if (gbxCustomer.Enabled)
                {
                    ClearAllBoxes();
                    tbCustomerName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    tbTelNo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    tbAdress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    tbInfo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                }

                if (gbxOperation.Enabled)
                {
                    ClearAllBoxes();
                    tbOperation.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    tbCost.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    tbPaid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    //Arada Borcun olduğu sütun var dikkat o yüzden 2 atladım
                    dtpOperationDate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value);
                    dtpReminderDate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value);
                }
            });
        }

        //Bundan sonrası maximize minimize işlemleri için çözünürlük kodları

        protected override void WndProc(ref Message m)
        {
            float currentWidth = 1699;
            float currentHeight = 1043;
            float widthRate, heightRate;
            Rectangle resolution = new Rectangle();
            DEVMODE mode = GetCurrentSettings();
            resolution.Width = (int)mode.dmPelsWidth; //Bu sayede çözünürlük bilgisini sistemden çektim ve otomatik ölçeklendirmeyi hesaba katmadan 1920x1080 bilgisine ulaştım :)
            resolution.Height = (int)mode.dmPelsHeight; //Aşağıdaki kod daha fazla basitleştirilemiliyor çünkü
            base.WndProc(ref m);

            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                // Check your window state here
                if (m.WParam == new IntPtr(0xF030)) // Maximize event - SC_MAXIMIZE from Winuser.h
                {
                    widthRate = (resolution.Width / currentWidth);
                    heightRate = (resolution.Height / currentHeight);
                    this.Scale(new SizeF(widthRate, heightRate));
                }

                if (m.WParam == new IntPtr(0xF120)) // Restore event - SC_RESTORE from Winuser.h
                {
                    widthRate = (currentWidth / resolution.Width);
                    heightRate = (currentHeight / resolution.Height);
                    this.Scale(new SizeF(widthRate, heightRate));
                }

                if (m.WParam == new IntPtr(0xF020)) // SC_MINIMIZE
                {

                    widthRate = (resolution.Width / currentWidth);
                    heightRate = (resolution.Height / currentHeight);
                    this.Scale(new SizeF(widthRate, heightRate));
                }
            }
        }

        //Benim laptopda %125 otomatik ölçeklendirme olduğu için Screen.PrimaryScreen.Bounds.Width ya da Height kullanınca 1920x1080 alması gereken formatı 1536x864 olarak alıyor,
        //Dolayısıyla yukarıdaki kodlar doğru çözünürlük için çalışmıyor, bu yüzden çözünürlük bilgisini direkt olarak sistem user32.dll'den alarak 1920x1080'e ulaştım
        //Kendi monitorümün çözünürlüğünü bildiğim için direkt yukarıda bu değerleri yazabilirdim, ancak programı başka bir bilgisayarda kullanan kişinin farklı bir çözünürlüğü olabilir
        //Aşağıdaki kodları aldığım websitesi: https://www.codeproject.com/Articles/36664/Changing-Display-Settings-Programmatically#Introduction
        //Kendi ihtiyacıma göre biraz modifiye ettim

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean EnumDisplaySettings(
            [param: MarshalAs(UnmanagedType.LPTStr)]
            string lpszDeviceName,
            [param: MarshalAs(UnmanagedType.U4)]
            int iModeNum,
            [In, Out]
            ref DEVMODE lpDevMode);

        public struct POINTL
        {
            [MarshalAs(UnmanagedType.I4)]
            public int x;
            [MarshalAs(UnmanagedType.I4)]
            public int y;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DEVMODE
        {
            // You can define the following constant
            // but OUTSIDE the structure because you know
            // that size and layout of the structure
            // is very important
            // CCHDEVICENAME = 32 = 0x50
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            // In addition you can define the last character array
            // as following:
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            //public Char[] dmDeviceName;

            // After the 32-bytes array
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmSpecVersion;

            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmDriverVersion;

            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmSize;

            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmDriverExtra;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmFields;

            public POINTL dmPosition;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDisplayOrientation;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDisplayFixedOutput;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmColor;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmDuplex;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmYResolution;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmTTOption;

            [MarshalAs(UnmanagedType.I2)]
            public Int16 dmCollate;

            // CCHDEVICENAME = 32 = 0x50
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            // Also can be defined as
            //[MarshalAs(UnmanagedType.ByValArray,
            //    SizeConst = 32, ArraySubType = UnmanagedType.U1)]
            //public Byte[] dmFormName;

            [MarshalAs(UnmanagedType.U2)]
            public UInt16 dmLogPixels;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmBitsPerPel;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmPelsWidth;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmPelsHeight;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDisplayFlags;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDisplayFrequency;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmICMMethod;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmICMIntent;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmMediaType;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmDitherType;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmReserved1;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmReserved2;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmPanningWidth;

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dmPanningHeight;
        }
        public static DEVMODE GetCurrentSettings()
        {
            DEVMODE mode = new DEVMODE();
            mode.dmSize = (ushort)Marshal.SizeOf(mode);
            EnumDisplaySettings(null, -1, ref mode);
            return mode;
        }
    }
}
