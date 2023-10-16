using System;
using System.Linq;
using System.Windows;
using WorldPC.Entities;

namespace WorldPC
{
    /// <summary>
    /// Логика взаимодействия для OrderOnRepair.xaml
    /// </summary>
    public partial class OrderOnRepair : Window
    {
        public WorldPCEntities _context = new WorldPCEntities();
        public static int clientId;
        public OrderOnRepair(int id)
        {
            InitializeComponent();
            clientId = id;
            var types = _context.type.ToList();
            typeList.ItemsSource = types;
            typeList.DisplayMemberPath = "name";
        }

        private void CreateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newModel = new model
                {
                    type_id = typeList.SelectedIndex + 1,
                    name = nameTb.Text,
                };
                _context.model.Add(newModel);
                int modelId = newModel.id;
                var newEquipment = new computer_equipment
                {
                    model_id = modelId,
                    characteristic = $"{nameTb.Text} " + $"{reasonTb.Text}"
                };
                _context.computer_equipment.Add(newEquipment);
                int equipmentId = newEquipment.id;
                var newOrderRepair = new repair_order
                {
                    delivery_date = DateTime.Now,
                    name = nameTb.Text,
                    client_id = clientId,
                    describe = reasonTb.Text,
                    staff_id = null,
                    computer_equipment_id = equipmentId,
                    status_id = 1
                };
                _context.repair_order.Add(newOrderRepair);
                _context.SaveChanges();

                MessageBox.Show("Заказ успешно оформлен!");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
