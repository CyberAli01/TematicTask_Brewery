using BreweryApp.Models;
using BreweryApp.Services;

namespace BreweryApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly DataService _dataService;
        private List<Order> _orders;

        public MainForm()
        {
            InitializeComponent();
            _dataService = new DataService();
            _orders = _dataService.GetOrdersWithDetails();
            SetupUI();
        }

        private void SetupUI()
        {
            statusList.SelectedIndexChanged += (s, e) => UpdateOrders();
            ordersGrid.CellDoubleClick += (s, e) => ShowOrderDetails();
            btnCard.Click += (s, e) => ShowClientCard();
            searchBox.TextChanged += (s, e) => SearchOrders(searchBox.Text);

            ordersGrid.AutoGenerateColumns = false;
            ordersGrid.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    DataPropertyName = "Id",
                    HeaderText = "Номер"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "OrderDate",
                    DataPropertyName = "OrderDate",
                    HeaderText = "Дата"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Client",
                    DataPropertyName = "Client",
                    HeaderText = "Клиент"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    DataPropertyName = "Total",
                    HeaderText = "Сумма"
                }
            );

            rightSplit.Panel1.Controls.Add(searchBox);
            rightSplit.Panel1.Controls.Add(btnCard);

            searchBox.Dock = DockStyle.Top;
            btnCard.Dock = DockStyle.Bottom;

            UpdateOrders();
        }

        private void UpdateOrders()
        {
            try
            {
                var selectedStatus = statusList.SelectedItem?.ToString();
                var filteredOrders = _orders
                    .Where(o => o.Status == selectedStatus)
                    .Select(o => new
                    {
                        o.Id,
                        OrderDate = o.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                        Client = o.Client?.Name ?? "Неизвестно",
                        o.Total
                    })
                    .ToList();

                ordersGrid.DataSource = filteredOrders;
                ordersGrid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении списка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowOrderDetails()
        {
            if (ordersGrid.CurrentRow == null || ordersGrid.CurrentRow.Index < 0) return;

            try
            {
                int orderId = (int)ordersGrid.CurrentRow.Cells["Id"].Value;
                var order = _orders.FirstOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    MessageBox.Show("Заказ не найден!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                txtDetails.Text = $@"Заказ №{order.Id}
                        Дата: {order.OrderDate:dd.MM.yyyy HH:mm}
                        Клиент: {order.Client?.Name ?? "Неизвестно"}
                        Телефон: {order.Client?.Phone ?? "Нет данных"}
                        Сумма: {order.Total} ₽
                        Статус: {order.Status}";

                var beerImage = order.OrderBeers?.FirstOrDefault()?.Beer?.ImagePath;
                picBeer.Image = !string.IsNullOrEmpty(beerImage) && File.Exists(beerImage)
                    ? Image.FromFile(beerImage)
                    : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке деталей: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowClientCard()
        {
            try
            {
                if (ordersGrid.CurrentRow == null || ordersGrid.CurrentRow.Index < 0)
                {
                    MessageBox.Show("Выберите заказ из таблицы!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orderId = (int)ordersGrid.CurrentRow.Cells["Id"].Value;
                var order = _orders.FirstOrDefault(o => o.Id == orderId);

                if (order == null)
                {
                    MessageBox.Show("Данные клиента не найдены!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var dlg = new OrderCardForm(order, _dataService))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                        UpdateOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии карточки: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchOrders(string query)
        {
            try
            {
                var filtered = _orders
                    .Where(o =>
                        o.Id.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) 
                        || o.Client?.Name?.Contains(query, StringComparison.OrdinalIgnoreCase) 
                        == true 
                        || o.Client?.Phone?.Contains(query, StringComparison.OrdinalIgnoreCase) 
                        == true)
                    .Select(o => new
                    {
                        o.Id,
                        OrderDate = o.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                        Client = o.Client?.Name ?? "Неизвестно",
                        o.Total
                    })
                    .ToList();

                ordersGrid.DataSource = filtered;
                ordersGrid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}