using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace course_work
{
    public partial class Form1 : Form
    {
        Student student;
        Study[] study;
        Input_study input = new Input_study();
        Show show = new Show();
        internal int count_stud = 0, count_record = 0;
        public List<double> marks = new List<double>(); // хранит оценки для подальшего просмотра их пользователем
        List<int> index_student = new List<int>(); //хранит индексы студентов 
        List<double> average_mark = new List<double>(); //хранит в себе средние оценки 
        int index_search = 0, k = 0, count = 0;
        public Form1()
        {
            student = new Student();
            study = new Study[5];
            for (int i = 0; i < 5; i++)
            {
                study[i] = new Study();
            }
            InitializeComponent();
            Menu.TabPages.Remove(tabPageEdit);
            button_check_password.Enabled = false;
            button_Delete.Enabled = false;
           // Export_List_Teachers(); //подгружает данные в ComboBox  для выбора преподавателя
            richText.Text += "История действий:\n";
        }
        //------------------------Functions-----------------------------
        void Input_student()
        {
            student.Name = textBox_name.Text;
            student.Record_number = textBox_record.Text;
            student.Name_faculty = textBox_faculty.Text;
            student.Course = Convert.ToString(numeric_course.Value);
            for (int i = 0; i < 5; i++)
            {
                input.ShowDialog();
                if (input.check_enabled == 1) // проверка на нажатие "Cancel"
                {
                    break;
                }
            }
            if (input.check_enabled != 1)
            {
                dataGridView.Rows.Add(textBox_name.Text, textBox_record.Text, textBox_faculty.Text, numeric_course.Value,
                    input.study[0].Subject, input.study[0].Name_teacher, input.study[0].Mark,
                    input.study[1].Subject, input.study[1].Name_teacher, input.study[1].Mark,
                    input.study[2].Subject, input.study[2].Name_teacher, input.study[2].Mark,
                    input.study[3].Subject, input.study[3].Name_teacher, input.study[3].Mark,
                    input.study[4].Subject, input.study[4].Name_teacher, input.study[4].Mark);
                richText.Text += "Студент был добавлен\n";
                MessageBox.Show("Студент упешно добавлен!");
                Button_true();
            }
        }
        void Button_true()
        {
            // разблокировка кнопок
            button_discipline.Enabled = true;
            button_thebest.Enabled = true;
            button_dupes.Enabled = true;
            remove_losers.Enabled = true;
            button_search.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }
        void Fill_Form_Show()
        {
            if (show.dataGridViewShow.RowCount != 0)
            {
                for (int i = show.dataGridViewShow.RowCount - 1; i >= 0; i--)
                {
                    show.dataGridViewShow.Rows.RemoveAt(i); // очищаем все записи 
                }
            }
            for (int i = 0; i < marks.Count; i++)
            {
                show.dataGridViewShow.Rows.Add();
                for (int j = 0; j < 4; j++)
                {
                    show.dataGridViewShow.Rows[i].Cells[j].Value = dataGridView.Rows[index_student[i]].Cells[j].Value;
                }
                show.dataGridViewShow.Rows[i].Cells[4].Value = marks[i];
            }
            show.dataGridViewShow.Sort(show.dataGridViewShow.Columns[4], ListSortDirection.Ascending);
            show.dataGridViewShow.Refresh();
            show.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }
        void Average_mark()
        {
            k = 6;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                average_mark.Add(0);
                k = 6;
                for (int j = 0; j < 5; j++)
                {
                    average_mark[i] += Convert.ToDouble(dataGridView.Rows[i].Cells[k].Value.ToString());
                    k += 3;
                }
                average_mark[i] /= 5;
            }
        }
        /*void Export_List_Teachers()
        {
            string path = "List of the teachers.txt";
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
            for (int i = 0; i < 10; i++)
            {
                if (reader.PeekChar() != -1)
                {
                    input.comboBox_teacher.Items.Add(reader.ReadString());
                }
                else
                {
                    reader.Close();
                    break;
                }
            }
        }*/
        void Generate_Password()
        {
            int pin;
            Random rand = new Random();
            pin = rand.Next(999, 9999);  // генерация пароля
            textBox_password.Text = Convert.ToString(pin);
        }
        void Search_Student()
        {
            count = 0;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (textBox_search.Text == dataGridView.Rows[i].Cells[1].Value.ToString()) // поиск по номеру зачетки
                {
                    richTextBox_search.Text = "Имя.Фамилия: " + dataGridView.Rows[i].Cells[0].Value.ToString() +
                        "\nНомер зачетки: " + dataGridView.Rows[i].Cells[1].Value.ToString() +
                        "\nФакультетy: " + dataGridView.Rows[i].Cells[2].Value.ToString() +
                        "\nКурс: " + dataGridView.Rows[i].Cells[3].Value.ToString();
                    index_search = i;
                    count++;
                    richText.Text += dataGridView.Rows[index_search].Cells[0].Value.ToString() + "найден\n";
                    button_check_password.Enabled = true;
                    button_Delete.Enabled = true;
                    break;
                }
            }
            if (count == 0)
            {
                richTextBox_search.Text = "Не найдено такого студента\n";
                button_check_password.Enabled = false;
                button_Delete.Enabled = false;
            }
        }
        void Search_the_best_student()
        {
            average_mark.Clear();
            Average_mark(); // запуск функции для нахождения средней оценки у студентов
            marks.Clear();
            index_student.Clear();
            k = 6;
            count = 0;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (average_mark[i] >= 4)
                {
                    marks.Add(average_mark[i]); // сохраняем оценку
                    index_student.Add(i); // сохраняем индекс студента
                }
                else
                    count++;
            }
            if (count == dataGridView.RowCount)
                MessageBox.Show("Не найдено такого студента\n");
            else
            {
                show.richTextBox1.Text = "Лучший студент:";
                Fill_Form_Show(); // запуск новой формы для вывода лучших студентов на экран
                show.ShowDialog();
            }
           richText.Text += "Лучший студент был найден\n";
        }
        void Search_the_losers()
        {
            average_mark.Clear();
            Average_mark(); // запуск функции для нахождения средней оценки у студентов
            marks.Clear();
            index_student.Clear();
            k = 6;
            count = 0;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                k = 6;
                for (int j = 0; j < 5; j++)
                {
                    if (Convert.ToInt32(dataGridView.Rows[i].Cells[k].Value) == 2)
                    {
                        marks.Add(average_mark[i]); // сохраняем оценку
                        index_student.Add(i); // сохраняем индекс студента
                        break;
                    }
                    else
                        count++;
                    k += 3;
                }
            }
            if (count == dataGridView.RowCount * 5)
                MessageBox.Show("Не найдено такого студента\n");
            else
            {
                show.richTextBox1.Text = "Студенты имеющие двойки:";
                Fill_Form_Show(); // запуск новой формы для вывода худших студентов на экран
                show.ShowDialog();
            }
           richText.Text += "Студент имеющий двойки был найден\n";
        }
        void Open_File_txt()
        {
            if (dataGridView.RowCount != 0)
            {
                for (int i = dataGridView.RowCount - 1; i >= 0; i--)
                {
                    dataGridView.Rows.RemoveAt(i); // очищаем все записи перед открытием нового файла
                }
            }
            dataGridView.Rows.Add();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) // открытие диалогового окна
                return;
            string path = openFileDialog1.FileName;
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (reader.PeekChar() != -1)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        dataGridView.Rows[i].Cells[j].Value = reader.ReadString(); // счытивание данных с файла в таблицу
                    }
                    dataGridView.Rows.Add();
                }
                else
                {
                    reader.Close();
                    break;
                }
            }
            dataGridView.Rows.RemoveAt(dataGridView.RowCount - 1);
        }
        void Save_File_txt()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) // открытие диалогового окна
                return;
            string path = saveFileDialog1.FileName;
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    writer.Write(dataGridView.Rows[i].Cells[j].Value.ToString()); // запись данных в файл                    
                }
            }
            writer.Close();
        }
        void Difficult_subject()
        {
            int p = 0, n, s = 0, check_on_check = 0, Count = 0;
            n = dataGridView.RowCount * 5;
            string[] dicipline = new string[n]; // массив для хранения названия предметов
            int[] count = new int[n]; // массив для хранения количество двоек
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                k = 6;
                p = 4;
                for (int j = 0; j < 5; j++)
                {
                    if (Convert.ToInt32(dataGridView.Rows[i].Cells[k].Value) == 2) // поиск предмета с оценкой в 2
                    {
                        Count++;
                        check_on_check = 0;
                        if (s == 0)
                        {
                            dicipline[s] = dataGridView.Rows[i].Cells[p].Value.ToString(); // запись предмета 
                            count[s]++;
                            k += 3;
                            p += 3;
                            s++;
                            continue;
                        }
                        for (int l = 0; l < s; l++)
                        {
                            if (dataGridView.Rows[i].Cells[p].Value.ToString() == dicipline[l]) // проверка на названия предмета
                            {
                                count[l]++;
                                check_on_check++;
                                break;
                            }
                        }
                        if (check_on_check == 0)
                        {
                            dicipline[s] = dataGridView.Rows[i].Cells[p].Value.ToString();
                            count[s]++;
                            s++;
                        }
                    }
                    k += 3;
                    p += 3;
                }
            }
            int max = count[0];
            for (int i = 0; i < s; i++)
            {
                if (count[i] >= max)
                {
                    max = count[i]; // нахождение предмета с найбольшим количеством двоек
                    p = i;
                }
            }
            if (Count == 0)
                MessageBox.Show("Не найдено такого предмета");
            else
                MessageBox.Show("Предмет: " + dicipline[p] + "\n");
        }
        void Check_password()
        {
            if (textBox_check_password.Text == textBox_password.Text && textBox_check_password.Text != "")// проверка пароля
            {
                Menu.TabPages.Insert(3, tabPageEdit);
                Menu.SelectedTab = Menu.TabPages[3];
                button_check_password.Enabled = false;
                button_Delete.Enabled = false;
            }
            else
                MessageBox.Show("Неправильный пароль!\nПосмотрите ваш пароль на странице Добавить и повторите действие");

            edit_name.Text = dataGridView.Rows[index_search].Cells[0].Value.ToString();
            edit_record.Text = dataGridView.Rows[index_search].Cells[1].Value.ToString();
            edit_faculty.Text = dataGridView.Rows[index_search].Cells[2].Value.ToString();
            edit_course.Value = Convert.ToDecimal(dataGridView.Rows[index_search].Cells[3].Value);
        }
        void Remove_student()
        {
            string name = dataGridView.Rows[index_search].Cells[0].Value.ToString();
            dataGridView.Rows.RemoveAt(index_search); // удаляем студента из базы по индексу найденому с помощью поиска
            dataGridView.Refresh();
            textBox_search.Text = "";
            MessageBox.Show("Все данные о студенте успешно удаленны");
            richText.Text += "The student " + name +
               " was deleted from database\n";
        }
        void Choose_subject()
        {
            //По нажатию кнопки выбираем предмет для редактирования 
            int selection = Convert.ToInt32(choose_subject.Value);
            switch (selection)
            {
                case 1:
                    edit_subject.Text = dataGridView.Rows[index_search].Cells[4].Value.ToString();
                    edit_teacher.Text = dataGridView.Rows[index_search].Cells[5].Value.ToString();
                    edit_mark.Value = Convert.ToDecimal(dataGridView.Rows[index_search].Cells[6].Value);
                    break;
                case 2:
                    edit_subject.Text = dataGridView.Rows[index_search].Cells[7].Value.ToString();
                    edit_teacher.Text = dataGridView.Rows[index_search].Cells[8].Value.ToString();
                    edit_mark.Value = Convert.ToDecimal(dataGridView.Rows[index_search].Cells[9].Value);
                    break;
                case 3:
                    edit_subject.Text = dataGridView.Rows[index_search].Cells[10].Value.ToString();
                    edit_teacher.Text = dataGridView.Rows[index_search].Cells[11].Value.ToString();
                    edit_mark.Value = Convert.ToDecimal(dataGridView.Rows[index_search].Cells[12].Value);
                    break;
                case 4:
                    edit_subject.Text = dataGridView.Rows[index_search].Cells[13].Value.ToString();
                    edit_teacher.Text = dataGridView.Rows[index_search].Cells[14].Value.ToString();
                    edit_mark.Value = Convert.ToDecimal(dataGridView.Rows[index_search].Cells[15].Value);
                    break;
                case 5:
                    edit_subject.Text = dataGridView.Rows[index_search].Cells[16].Value.ToString();
                    edit_teacher.Text = dataGridView.Rows[index_search].Cells[17].Value.ToString();
                    edit_mark.Value = Convert.ToDecimal(dataGridView.Rows[index_search].Cells[18].Value);
                    break;
                default:
                    break;
            }
        }
        void Edit_main_data()
        {
            count = 0;
            dataGridView.Rows[index_search].Cells[0].Value = edit_name.Text;
            dataGridView.Rows[index_search].Cells[2].Value = edit_faculty.Text;
            dataGridView.Rows[index_search].Cells[3].Value = edit_course.Value;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (index_search != i)
                {
                    if (edit_record.Text == dataGridView.Rows[i].Cells[1].Value.ToString()) // проверка на коректность введенного номера зачетки
                    {
                        count = 1;
                        break;
                    }
                    else
                        count = 2;
                }
                else
                    continue;
            }
            if (count == 2)
                dataGridView.Rows[index_search].Cells[1].Value = edit_record.Text;
            else if (count == 1)
                MessageBox.Show("Ошибка!\n Повторите ввод");
        }
        void Edit_progress()
        {
            int selection = Convert.ToInt32(choose_subject.Value);
            switch (selection)
            {
                case 1:
                    dataGridView.Rows[index_search].Cells[4].Value = edit_subject.Text;
                    dataGridView.Rows[index_search].Cells[5].Value = edit_teacher.Text;
                    dataGridView.Rows[index_search].Cells[6].Value = edit_mark.Value;
                    break;
                case 2:
                    dataGridView.Rows[index_search].Cells[7].Value = edit_subject.Text;
                    dataGridView.Rows[index_search].Cells[8].Value = edit_teacher.Text;
                    dataGridView.Rows[index_search].Cells[9].Value = edit_mark.Value;
                    break;
                case 3:
                    dataGridView.Rows[index_search].Cells[10].Value = edit_subject.Text;
                    dataGridView.Rows[index_search].Cells[11].Value = edit_teacher.Text;
                    dataGridView.Rows[index_search].Cells[12].Value = edit_mark.Value;
                    break;
                case 4:
                    dataGridView.Rows[index_search].Cells[13].Value = edit_subject.Text;
                    dataGridView.Rows[index_search].Cells[14].Value = edit_teacher.Text;
                    dataGridView.Rows[index_search].Cells[15].Value = edit_mark.Value;
                    break;
                case 5:
                    dataGridView.Rows[index_search].Cells[16].Value = edit_subject.Text;
                    dataGridView.Rows[index_search].Cells[17].Value = edit_teacher.Text;
                    dataGridView.Rows[index_search].Cells[18].Value = edit_mark.Value;
                    break;
                default:
                    break;
            }
        }
        void Function_Remove()
        {
            int k = 0, number = 0, count = 0, n_row = dataGridView.RowCount;
            while (number != dataGridView.RowCount)
            {
                k = 6;
                count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (Convert.ToInt32(dataGridView.Rows[number].Cells[k].Value) == 2)
                    {
                        dataGridView.Rows.RemoveAt(number); // удаляем студента с оценкой в 2 бала                       
                        count = 1;
                        break;
                    }
                    k += 3;
                }
                if (count != 1)
                {
                    number++;
                }
            }
            dataGridView.Refresh();
            if (dataGridView.RowCount != n_row)
            {
                DialogResult result = MessageBox.Show("данные о студентах успешно удаленны\n" +
                                "Вы хотите увидить таблицу?", "Отмена", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Menu.SelectedTab = Menu.TabPages[1];
                richText.Text += "Данный о студенте у которого были двойки удаленны";
            }
            else
                MessageBox.Show("Не найдено таких студентов");
        }
        void Check_input_text(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\b')) return;
            if (e.KeyChar.Equals(' ')) return;

            var tb = (TextBox)sender;
            if (e.KeyChar.Equals('-'))
            {
                e.Handled = tb.SelectionStart == 0 || tb.Text[tb.SelectionStart - 1].Equals('-');
                if (!e.Handled)
                {
                    return;
                }
            }
            e.Handled = !char.IsLetter(e.KeyChar);
        }
        void Check_input_digit(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\b')) return;
            e.Handled = !char.IsDigit(e.KeyChar);
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        //!
        private void button_add_Click(object sender, EventArgs e)
        {
            input.check_enabled = 0;
            count_record = 0;
            if (dataGridView.RowCount != 0)
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (dataGridView.Rows[i].Cells[1].Value.ToString() == textBox_record.Text) // проверка на сходимость номеров зачетки
                        count_record++;
                }
                if (count_record == 0 && textBox_name.Text != "" && textBox_record.Text != "")
                    Input_student();
                else
                    MessageBox.Show("Этот студент уже существует.\nПовторите ввод");
            }
            else
            {
                if (textBox_name.Text != "" && textBox_record.Text != "")
                    Input_student();
                else
                    MessageBox.Show("Ошибка ввода!.\nПовторите пожалуйста");
            }
        }
        
        private void button_password_Click_1(object sender, EventArgs e)
        {
            Generate_Password();
           richText.Text += "пароль сгенерировали: " + textBox_password.Text + "\n";
        }
       
        private void button_dupes_Click(object sender, EventArgs e)
        {
            Search_the_losers();
        }
       
        private void button_search_Click(object sender, EventArgs e)
        {
            Search_Student();
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_File_txt();
            MessageBox.Show("Файл открыт");
            Button_true();
            richText.Text += "Ваши данный из файла были открыты\n";
        }

       
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_File_txt();
            MessageBox.Show("Файл сохранен");
            richText.Text += "\nВаши данные были сохранены в файл";
        }
        
        private void button_discipline_Click(object sender, EventArgs e)
        {
            Difficult_subject();
            richText.Text += "Найден предмет, по которому больше двоек\n";
        }
        
        private void button_check_password_Click(object sender, EventArgs e)
        {
            Check_password();
        }
        
        private void button_Delete_Click(object sender, EventArgs e)
        {
            Remove_student();
        }
        private void button_choose_subject_Click(object sender, EventArgs e)
        {
            Choose_subject();
        }
        
        private void button_change_data_Click(object sender, EventArgs e)
        {
            Edit_main_data();
        }
        
        private void button_change_progress_Click(object sender, EventArgs e)
        {
            Edit_progress();
        }
        
        private void save_changes_Click(object sender, EventArgs e)
        {
            dataGridView.Refresh();
            textBox_search.Text = "";
            MessageBox.Show("Введенные данные сохранены");
            richText.Text += "База данных отредоктирована";
            Menu.TabPages.Remove(tabPageEdit); // скрываем раздел редактирование
        }
        
        private void remove_losers_Click(object sender, EventArgs e)
        {
            Function_Remove();
        }
       
        private void Form1_HelpRequested_1(object sender, HelpEventArgs hlpevent)
        {
            Process.Start(@"C:\Users\User\Downloads\Manual.chm"); // запускает Справку
        }
        //!
        private void referenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\User\Downloads\Manual.chm"); // запускает справку
        }

        //-------------------------------Checks----------------------------------------        
        private void textBox_name_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Check_input_text(sender, e);
        }
        private void edit_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_input_text(sender, e);
        }
        private void edit_teacher_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_input_text(sender, e);
        }
        private void edit_subject_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_input_text(sender, e);
        }
        private void textBox_faculty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_input_text(sender, e);
        }

        private void richText_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void numeric_course_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox_check_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_search_TextChanged(object sender, EventArgs e)
        {

        }
              
        private void richText_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button_thebest_Click(object sender, EventArgs e)
        {
            Search_the_best_student();
        }

        private void button_dupes_Click_2(object sender, EventArgs e)
        {
            Search_the_losers();
        }

        private void button_discipline_Click_2(object sender, EventArgs e)
        {
            Difficult_subject();
        }

        private void remove_losers_Click_2(object sender, EventArgs e)
        {
            Function_Remove();
        }

        private void edit_faculty_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_input_text(sender, e);
        }
        private void edit_record_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_input_digit(sender, e);
        }
        private void textBox_record_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check_input_digit(sender, e);
        }

    }
}
