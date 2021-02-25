using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Concrete;
using BusinessLogic.Tools.Feedback.Abstract;
using BusinessLogic.Tools.Feedback.Concrete;
using BusinessLogic.Tools.Logger.Abstract;
using BusinessLogic.Tools.Logger.Concrete;
using Entities.Concrete;

namespace UI.WinForm
{
    public partial class Form1 : Form
    {
        //Program setup haline gelip kısayol oluşturduktan sonra yönetici olarak başlatabilsin diye app.manifest dosyasında değişiklik yaptım
        private CustomerManager _customerManager;
        private OperationManager _operationManager;
        private ReminderDtoManager _reminderDtoManager;
        private IBusinessLogger _logger;
        private IBusinessMailSender _mailSender;
        private DgwCellEnlarger _enlarger;
        public Form1()
        {
            _customerManager = new CustomerManager();
            _operationManager = new OperationManager();
            _reminderDtoManager = new ReminderDtoManager();
            _logger = new BusinessFileLogger(); //yarın bir gün veritabanına loglamak gerekirse sadece burası değişecek
            _mailSender = new BusinessLogSender();
            _enlarger = new DgwCellEnlarger();
            _enlarger.BringToFront();
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ShowCellToolTips = false; //Hücrenin üzerine gelince çıkan küçük bilgilendirme kutusunu kapatır, çünkü kendim tasarladım
                LoadDataGridView(_customerManager.GetAllCustomers());
                cbReminder.SelectedItem = "7";
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                MessageBox.Show(exception.Message);
                this.Close();
            }
        }

        private void tableLayoutPanel2_Click(object sender, EventArgs e)
        {
            ClearAllBoxes();
            dataGridView1.CurrentCell = null; //formda disabled bir groupbox'un bir yerine tıklandığında dgw'deki seçimi iptal etsin deyü
        }

        private void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                _customerManager.Insert(SetCustomer(new Customer()));
                //bu şekilde yapmamın sebebi yukarıda global olarak customer nesnesi tanımlamak büyük sıkıntı
                //her seferinde farklı değerlerle çalışmamız gerektiği için nesne sadece çalışcağı metod için oluşsun ve metod işini görünce
                //kendini garbage collector'a bıraksın, başka bir metod için başka bir nesne oluşsun yoksa programda büyük sorunlar çıkıyor
                List<Customer> customers = _customerManager.GetAllCustomers();
                LoadDataGridView(customers);
                dataGridView1.CurrentCell = dataGridView1.Rows[customers.Count - 1].Cells[2];
            });
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                if (MessageBox.Show("Emin misiniz?", "Selamın Aleyküm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _customerManager.Update(SetCustomerForUpdate(new Customer()));
                    int selected = GetCurrentCell();
                    LoadDataGridView(_customerManager.GetAllCustomers());
                    dataGridView1.CurrentCell = dataGridView1.Rows[selected].Cells[2];
                }
            });
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                if (MessageBox.Show("Emin misiniz?", "Selamın Aleyküm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _customerManager.Delete(new Customer() { MusteriID = GetCustomerIDFromDgw() });
                    LoadDataGridView(_customerManager.GetAllCustomers());
                }
            });
        }

        private void btnGetCustomerByName_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                LoadDataGridView(_customerManager.GetCustomerByName(tbCustomerName.Text));
            });
        }

        private int _currentCustomerID;
        private void btnGetOperationsByCustomerID_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                _currentCustomerID = GetCustomerIDFromDgw();

                ClearAllBoxes();
                tbCustomerName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbTelNo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tbAdress.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbInfo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                LoadDataGridView(_operationManager.GetOperationsByCustomerID(_currentCustomerID));
            });
        }

        private void btnInsertOperation_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                Operation operation = new Operation(); //operation'a gelen değerleri kontrol etmek için böyle yapmak daha doğru
                SetOperation(operation);
                _operationManager.Insert(operation);
                List<Operation> operations = _operationManager.GetOperationsByCustomerID(_currentCustomerID);
                LoadDataGridView(operations);
                dataGridView1.CurrentCell = dataGridView1.Rows[operations.Count - 1].Cells[2];
            });
        }

        private void btnUpdateOperation_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                if (MessageBox.Show("Emin misiniz?", "Selamın Aleyküm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Operation operation = new Operation();
                    SetOperationForUpdate(operation);
                    _operationManager.Update(operation);
                    int selected = GetCurrentCell(); //Update işlemi yapıldıktan sonra seçili satırı kaybetmemek için
                    LoadDataGridView(_operationManager.GetOperationsByCustomerID(_currentCustomerID));
                    dataGridView1.CurrentCell = dataGridView1.Rows[selected].Cells[2];
                }
            });
        }

        private void btnDeleteOperation_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                if (MessageBox.Show("Emin misiniz?", "Selamın Aleyküm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Operation operation = new Operation();
                    SetOperationForUpdate(operation);
                    _operationManager.Delete(operation);
                    LoadDataGridView(_operationManager.GetOperationsByCustomerID(_currentCustomerID));
                }
            });
        }
        private void btnSortOperationsByRemainingDay_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                LoadDataGridView(_operationManager.SortOperationsByRemainingDay(_currentCustomerID));
            });
        }

        private void btnGetAllCustomers_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                LoadDataGridView(_customerManager.GetAllCustomers());
                ClearAllBoxes();
            });
        }

        private bool _reminderDtoFlag;
        private void btnRemindDate_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                LoadDataGridView(_reminderDtoManager.GetAllReminderDtosByDay((Convert.ToInt32(cbReminder.Text))));
                _reminderDtoFlag = true;
                ClearAllBoxes();
            });
        }

        private void btnGetAllDebtor_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                LoadDataGridView(_reminderDtoManager.GetAllReminderDtosByDebt());
                _reminderDtoFlag = false;
                ClearAllBoxes();
            });
        }

        private void btnSortByName_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                if (gbxOperation.Enabled == false && gbxCustomer.Enabled)
                {
                    LoadDataGridView(_customerManager.SortCustomersByName());
                }

                if (gbxCustomer.Enabled == false && gbxOperation.Enabled)
                {
                    LoadDataGridView(_operationManager.SortOperationsByName(_currentCustomerID));
                }

                if (!gbxCustomer.Enabled && !gbxOperation.Enabled) //ikiside kapalıysa ReminderDto'lu tablo aktiftir
                {
                    if (_reminderDtoFlag) // eğer bayrak havadaysa kalan güne göre olan dto tablosu aktiftir
                    {
                        LoadDataGridView(_reminderDtoManager.SortReminderDtosByDayByName(GetRemainingDay()));
                    }
                    else // değilse borca göre olan tablo aktiftir
                    {
                        LoadDataGridView(_reminderDtoManager.SortReminderDtosByDebtByName());
                    }

                }
                ClearAllBoxes();
            });
        }

        private void btnSendErrorLog_Click(object sender, EventArgs e)
        {
            HandleException(() =>
            {
                _mailSender.SendMail();
            });
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright© Emre Ekerbiçer");
        }

        //Buradan sonrası hücreye sığmama ihtimali olan metinleri göstermek için hover efekti
        private int _columnIndex;
        private int _rowIndex;
        private int _timerCounter;
        private int _cellX;
        private int _cellY;
        private Rectangle _dgwCellLoc;
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _columnIndex = e.ColumnIndex;
            _rowIndex = e.RowIndex;
            timer1.Enabled = true;
        }
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            _enlarger.Visible = false;
            timer1.Enabled = false;
            _timerCounter = 0;
        }

        private void timer1_Tick(object sender, EventArgs e) //timer'ın intervali geçip her tetiklendiğinde döngü gibi çalışcak,interval yarım saniye ayarladım
        {
            HandleException(() =>
            {
                _timerCounter++;
                if (_timerCounter == 2) //İlgili hücrenin üzerinde 1'sn den fazla kalırsa
                {
                    _dgwCellLoc = dataGridView1.GetCellDisplayRectangle(_columnIndex, _rowIndex, false);
                    _cellX = _dgwCellLoc.Left + dataGridView1.Left + this.Left + 9; //projeyi table layoutlar ile responsive tasarıma geçirdiğim için buradaki formüllerde değişiklik oldu
                    _cellY = _dgwCellLoc.Top + dataGridView1.Top + tableLayoutPanel2.Bottom + _dgwCellLoc.Height - (_enlarger.tbHover.Bottom - _enlarger.tbHover.Top);

                    if (_columnIndex >= 3 && _rowIndex >= 0 && gbxCustomer.Enabled) //Müşteriler tablosuna göre ayar
                    {
                        SetTBHover();
                    }

                    if (_columnIndex == 2 && _rowIndex >= 0 && gbxOperation.Enabled) //İşlemler tablosuna göre ayar
                    {
                        SetTBHover();
                    }

                    if (_columnIndex >= 2 && _columnIndex <= 4 && _rowIndex >= 0 && !gbxCustomer.Enabled && !gbxOperation.Enabled) //ReminderDtos tablosuna göre ayar
                    {
                        SetTBHover();
                    }
                }
            });
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillTextBoxes();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            FillTextBoxes();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            FillTextBoxes();
        }
    }
}
