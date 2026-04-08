using Army.Classes;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Army
{
    public partial class MainForm : Form
    {
        private ArmyData currentData;
        public MainForm()
        {
            InitializeComponent();
            StructureTree();
            LoadPicture();
        }
        public void LoadPicture()
        {
            pictureBox1.Image = Image.FromFile(@"..\..\..\Pictures\army.jpg");
            pictureBox2.Image = Image.FromFile(@"..\..\..\Pictures\army2.png");
        }
        public void StructureTree()
        {
            Tree.Nodes.Clear();
            TreeNode root = new TreeNode("Воинская часть");
            root.Nodes.Add("Военнослужащие");
            root.Nodes.Add("Военная техника");
            root.Nodes.Add("Наряды");
            Tree.Nodes.Add(root);
            Tree.ExpandAll();
        }
        private void UpdateTreeWithData()
        {
            if (currentData == null) return;
            TreeNode root = Tree.Nodes[0];
            TreeNode soldiersNode = root.Nodes[0];
            TreeNode technicsNode = root.Nodes[1];
            TreeNode dutiesNode = root.Nodes[2];
            soldiersNode.Nodes.Clear();
            technicsNode.Nodes.Clear();
            dutiesNode.Nodes.Clear();
            if (currentData.Soldiers != null)
            {
                foreach (var soldier in currentData.Soldiers)
                {
                    TreeNode node = new TreeNode($"{soldier.FullName}");
                    node.Tag = soldier;
                    soldiersNode.Nodes.Add(node);
                }
            }
            if (currentData.Technics != null)
            {
                foreach (var tec in currentData.Technics)
                {
                    TreeNode node = new TreeNode($"{tec.Name}");
                    node.Tag = tec;
                    technicsNode.Nodes.Add(node);
                }
            }
            if (currentData.Duties != null)
            {
                foreach (var duty in currentData.Duties)
                {
                    TreeNode node = new TreeNode($"{duty.TaskName}");
                    node.Tag = duty;
                    dutiesNode.Nodes.Add(node);
                }
            }
            Tree.ExpandAll();
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            UploadForm uploadform = new UploadForm();
            if (uploadform.ShowDialog() == DialogResult.OK)
            {
                string format = uploadform.SelectedFormat;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = @"..\..\..\Files";
                ofd.Title = $"Выберите {format} файл с данными";
                if (format == "XML")
                    ofd.Filter = "XML файлы (*.xml)|*.xml";
                else
                    ofd.Filter = "JSON файлы (*.json)|*.json";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (format == "XML")
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(ArmyData));
                            using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                                currentData = (ArmyData)serializer.Deserialize(fs);
                        }
                        else
                        {
                            string json = File.ReadAllText(ofd.FileName);
                            currentData = JsonConvert.DeserializeObject<ArmyData>(json);
                        }

                        UpdateTreeWithData();

                        MessageBox.Show($"Данные загружены!" +
                            $"\nСолдаты: {currentData.Soldiers.Count}\n" +
                            $"Техника: {currentData.Technics.Count}\n" +
                            $"Наряды: {currentData.Duties.Count}",
                            "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Close1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Show1_Click(object sender, EventArgs e)
        {
            if (currentData == null)
            {
                MessageBox.Show("Сначала загрузите файл через кнопку 'Загрузить'!",
                    "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var allItems = new System.Data.DataTable();
            allItems.Columns.Add("Тип");
            allItems.Columns.Add("ID");
            allItems.Columns.Add("Название");
            allItems.Columns.Add("Основное");
            allItems.Columns.Add("Дополнительно");
            foreach (var s in currentData.Soldiers)
            {
                string main = $"Звание: {s.Rank} Должность: {s.ServiceInfo?.Position} Подразделение: {s.ServiceInfo?.Unit}";
                string additional = $"Дата рождения: {s.PersonalInfo?.BirthDate.ToString("dd.MM.yyyy")} Паспорт: {s.PersonalInfo?.Passport} Адрес: {s.PersonalInfo?.Address} Дата призыва: {s.ServiceInfo?.EnlistmentDate.ToString("dd.MM.yyyy")} Тип службы: {s.ServiceInfo?.ContractType}";
                allItems.Rows.Add("Солдат", s.Id, s.FullName, main, additional);
            }
            foreach (var eq in currentData.Technics)
            {
                string main = $"Тип: {eq.TypeTechnics}\n Год выпуска: {eq.YearRelease}\n Вес: {eq.TechnicalSpecs?.Weight}";
                string additional = $"Мощность: {eq.TechnicalSpecs?.EnginePower} \nСкорость: {eq.TechnicalSpecs?.MaxSpeed} \nТопливо: {eq.TechnicalSpecs?.FuelCapacity} \nЭкипаж: {eq.CombatInfo?.Crew} \nВооружение: {eq.CombatInfo?.Armament} \nБоекомплект: {eq.CombatInfo?.Ammunition} \nБроня: {eq.CombatInfo?.Armor}";
                allItems.Rows.Add("Техника", eq.Id, eq.Name, main, additional);
            }
            foreach (var d in currentData.Duties)
            {
                string main = $"Приоритет: {d.Priority} \n Длительность: {d.Duration} ч.\n Командир: {d.AssignedSoldiers?.LeaderName}";
                string additional = $"ID командира: {d.AssignedSoldiers?.LeaderId} \nКол-во бойцов: {d.AssignedSoldiers?.MembersCount} \nСписок: {d.AssignedSoldiers?.MembersList} \nЗона: {d.LocationInfo?.Zone} \nКоординаты: {d.LocationInfo?.Coordinates} \nКПП: {d.LocationInfo?.Checkpoint} \nМаршрут: {d.LocationInfo?.Route}";
                allItems.Rows.Add("Наряд", d.Id, d.TaskName, main, additional);
            }
            Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Table.DataSource = allItems;
        }
        private void ShowSoldierDetails(Soldier s)
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Свойство");
            dt.Columns.Add("Значение");
            dt.Rows.Add("ID", s.Id);
            dt.Rows.Add("ФИО", s.FullName);
            dt.Rows.Add("Звание", s.Rank);
            dt.Rows.Add("Дата рождения", s.PersonalInfo?.BirthDate.ToString("dd.MM.yyyy"));
            dt.Rows.Add("Паспорт", s.PersonalInfo?.Passport);
            dt.Rows.Add("Адрес", s.PersonalInfo?.Address);
            dt.Rows.Add("Дата призыва", s.ServiceInfo?.EnlistmentDate.ToString("dd.MM.yyyy"));
            dt.Rows.Add("Подразделение", s.ServiceInfo?.Unit);
            dt.Rows.Add("Должность", s.ServiceInfo?.Position);
            dt.Rows.Add("Тип службы", s.ServiceInfo?.ContractType);
            Table.DataSource = dt;
            Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void ShowTechnicsDetails(MilitaryTechnics eq)
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Свойство");
            dt.Columns.Add("Значение");
            dt.Rows.Add("ID", eq.Id);
            dt.Rows.Add("Наименование", eq.Name);
            dt.Rows.Add("Тип", eq.TypeTechnics);
            dt.Rows.Add("Год выпуска", eq.YearRelease);
            dt.Rows.Add("Вес", eq.TechnicalSpecs?.Weight);
            dt.Rows.Add("Мощность двигателя", eq.TechnicalSpecs?.EnginePower);
            dt.Rows.Add("Макс. скорость", eq.TechnicalSpecs?.MaxSpeed);
            dt.Rows.Add("Запас топлива", eq.TechnicalSpecs?.FuelCapacity);
            dt.Rows.Add("Экипаж", eq.CombatInfo?.Crew);
            dt.Rows.Add("Вооружение", eq.CombatInfo?.Armament);
            dt.Rows.Add("Боекомплект", eq.CombatInfo?.Ammunition);
            dt.Rows.Add("Броня", eq.CombatInfo?.Armor);
            Table.DataSource = dt;
            Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void ShowDutyDetails(Duty d)
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Свойство");
            dt.Columns.Add("Значение");
            dt.Rows.Add("ID", d.Id);
            dt.Rows.Add("Задача", d.TaskName);
            dt.Rows.Add("Приоритет", d.Priority);
            dt.Rows.Add("Длительность (ч)", d.Duration);
            dt.Rows.Add("ID командира", d.AssignedSoldiers?.LeaderId);
            dt.Rows.Add("Командир", d.AssignedSoldiers?.LeaderName);
            dt.Rows.Add("Кол-во бойцов", d.AssignedSoldiers?.MembersCount);
            dt.Rows.Add("Список бойцов", d.AssignedSoldiers?.MembersList);
            dt.Rows.Add("Зона", d.LocationInfo?.Zone);
            dt.Rows.Add("Координаты", d.LocationInfo?.Coordinates);
            dt.Rows.Add("КПП", d.LocationInfo?.Checkpoint);
            dt.Rows.Add("Маршрут", d.LocationInfo?.Route);
            Table.DataSource = dt;
            Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (currentData == null) return;
            if (e.Node.Text == "Военнослужащие")
            {
                var dt = new System.Data.DataTable();
                dt.Columns.Add("Ноомер");
                dt.Columns.Add("ФИО");
                dt.Columns.Add("Звание");
                dt.Columns.Add("Дата рождения");
                dt.Columns.Add("Паспорт");
                dt.Columns.Add("Адрес");
                dt.Columns.Add("Дата призыва");
                dt.Columns.Add("Подразделение");
                dt.Columns.Add("Должность");
                dt.Columns.Add("Тип службы");
                foreach (var s in currentData.Soldiers)
                {
                    dt.Rows.Add(s.Id, s.FullName,s.Rank, s.PersonalInfo?.BirthDate.ToString("dd.MM.yyyy"), 
                        s.PersonalInfo?.Passport,s.PersonalInfo?.Address, s.ServiceInfo?.EnlistmentDate.ToString("dd.MM.yyyy"), 
                        s.ServiceInfo?.Unit, s.ServiceInfo?.Position, s.ServiceInfo?.ContractType);
                }
                Table.DataSource = dt;
                Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            if (e.Node.Text == "Военная техника")
            {
                var dt = new System.Data.DataTable();
                dt.Columns.Add("Номер");
                dt.Columns.Add("Наименование");
                dt.Columns.Add("Тип");
                dt.Columns.Add("Год выпуска");
                dt.Columns.Add("Вес");
                dt.Columns.Add("Мощность");
                dt.Columns.Add("Скорость");
                dt.Columns.Add("Топливо");
                dt.Columns.Add("Экипаж");
                dt.Columns.Add("Вооружение");
                dt.Columns.Add("Боекомплект");
                dt.Columns.Add("Броня");
                foreach (var eq in currentData.Technics) dt.Rows.Add(eq.Id, eq.Name, eq.TypeTechnics, eq.YearRelease, 
                    eq.TechnicalSpecs?.Weight, eq.TechnicalSpecs?.EnginePower, eq.TechnicalSpecs?.MaxSpeed, 
                    eq.TechnicalSpecs?.FuelCapacity, eq.CombatInfo?.Crew, eq.CombatInfo?.Armament, eq.CombatInfo?.Ammunition, 
                    eq.CombatInfo?.Armor);
                Table.DataSource = dt;
                Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                return;
            }
            if (e.Node.Text == "Наряды")
            {
                var dt = new System.Data.DataTable();
                dt.Columns.Add("Номер");
                dt.Columns.Add("Задача");
                dt.Columns.Add("Приоритет");
                dt.Columns.Add("Длительность");
                dt.Columns.Add("ID командира");
                dt.Columns.Add("Командир");
                dt.Columns.Add("Бойцов");
                dt.Columns.Add("Список");
                dt.Columns.Add("Зона");
                dt.Columns.Add("Координаты");
                dt.Columns.Add("КПП");
                dt.Columns.Add("Маршрут");
                foreach (var d in currentData.Duties) dt.Rows.Add(d.Id, d.TaskName, d.Priority, d.Duration, 
                    d.AssignedSoldiers?.LeaderId, d.AssignedSoldiers?.LeaderName, d.AssignedSoldiers?.MembersCount, 
                    d.AssignedSoldiers?.MembersList, d.LocationInfo?.Zone, d.LocationInfo?.Coordinates, 
                    d.LocationInfo?.Checkpoint, d.LocationInfo?.Route);
                Table.DataSource = dt;
                Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                return;
            }
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag is Soldier soldier)
                    ShowSoldierDetails(soldier);
                else if (e.Node.Tag is MilitaryTechnics technics)
                    ShowTechnicsDetails(technics);
                else if (e.Node.Tag is Duty duty)
                    ShowDutyDetails(duty);
            }
        }
    }
}
