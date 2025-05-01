using BreweryApp.Models;
using BreweryApp.Services;

namespace BreweryApp.Forms
{
    public partial class OrderCardForm : Form
    {
        private readonly Order _order;
        private readonly DataService _dataService;

        public OrderCardForm(Order order, DataService dataService)
        {
            InitializeComponent();
            _order = order;
            _dataService = dataService;
            SetupUI();
        }

        private void SetupUI()
        {
            Text = $"Заказ №{_order.Id} от {_order.OrderDate:dd.MM.yyyy}";

            lblTotal.Text = $"Общая сумма: {_order.Total} ₽";
            txtClient.Text = _order.Client?.Name ?? "Неизвестный клиент";

            lstBeers.Items.Clear();
            foreach (var ob in _order.OrderBeers)
            {
                lstBeers.Items.Add(
                    $"{ob.Beer?.Name ?? "Неизвестное пиво"} - " +
                    $"{ob.Quantity} шт. x {ob.Beer?.ABV ?? 0m} ₽ = " +
                    $"{ob.Quantity * (ob.Beer?.ABV ?? 0m)} ₽"
                );
            }

            cmbStatus.DataSource = new[] { "В обработке", "Готов", "Доставляется", "Завершен" };
            cmbStatus.SelectedItem = _order.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _order.Status = cmbStatus.SelectedItem!.ToString()!;
                _dataService.UpdateOrder(_order);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}