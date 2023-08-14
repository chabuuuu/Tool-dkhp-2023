using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace Tool_dkhp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string username;
        string password;
        string malop;
        class MyData
        {
            public string username { get; set; }
            public string password { get; set; }
            public string error { get; set; }

            public string autof5 { get; set; }

            public string[] malop { get; set; }
            public string[] dangkythanhcong { get; set; }
            public string[] dangkythatbai { get; set; }

        }
        public MainWindow()
        {
    
            InitializeComponent();
            MaLopBox.PreviewKeyDown += MaLopBox_PreviewKeyDown;

            UsernameBox.GotKeyboardFocus += UsernameBox_GotKeyboardFocus;
            UsernameBox.LostFocus += UsernameBox_LostFocus;

            // Hiển thị văn bản tạm thời ban đầu
            UsernameShowPlaceholderText();


            PasswordBox.GotKeyboardFocus += PasswordBox_GotKeyboardFocus;
            PasswordBox.LostFocus += PasswordBox_LostFocus;

            // Hiển thị văn bản tạm thời ban đầu
            PasswordShowPlaceholderText();



        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                PasswordShowPlaceholderText();
            }
        }

        private void PasswordBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (PasswordBox.Text == "Password")
            {
                PasswordBox.Text = "";
                PasswordBox.Foreground = Brushes.Black;
            }
        }

        private void UsernameShowPlaceholderText()
        {
            UsernameBox.Text = "Username";
            UsernameBox.Foreground = Brushes.Gray;
        }
        private void PasswordShowPlaceholderText()
        {
            PasswordBox.Text = "Password";
            PasswordBox.Foreground = Brushes.Gray;
        }


        private void UsernameBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (UsernameBox.Text == "Username")
            {
                UsernameBox.Text = "";
                UsernameBox.Foreground = Brushes.Black;
            }
        }

        private void UsernameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                UsernameShowPlaceholderText();
            }
        }



        private void MaLopBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = (TextBox)sender;
                int caretIndex = textBox.CaretIndex;
                string newText = textBox.Text.Insert(caretIndex, Environment.NewLine).Replace("\r", string.Empty);
                textBox.Text = newText;
                textBox.CaretIndex = caretIndex + Environment.NewLine.Length;
                e.Handled = true;
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            username = UsernameBox.Text;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(malop);
            string filePath = "setting.json";

            // Đọc tệp JSON
            string jsonContent = File.ReadAllText(filePath);

            // Giải mã JSON vào đối tượng (class) tương ứng
            MyData data = JsonSerializer.Deserialize<MyData>(jsonContent);

            // Sửa dữ liệu
            data.username = username;
            data.password = password;
            data.malop = malop.Split('\n');
            if (AutoF5.IsChecked == true)
            {
                data.autof5 = "True";
            }
            else
            {
                data.autof5 = "False";
            }
            
            // Ghi dữ liệu trở lại tệp JSON
            string updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, updatedJson);
            string message = "Mã lớp đăng ký: \n" + malop;
            MessageBox.Show(message);

            string exePath = @"tool.exe"; // Thay đổi đường dẫn tới file .exe của bạn

            // Tạo một quá trình mới để chạy file .exe
            Process process = new Process();

            // Thiết lập đường dẫn tới file .exe
            process.StartInfo.FileName = exePath;

            // Khởi động quá trình
            process.Start();

            // Chờ cho quá trình kết thúc
            process.WaitForExit();
            if (data.error != null)
            {
                MessageBox.Show(data.error);
            }
            else
            {
                message = "Đăng ký học phần thành công:\n" + string.Join(Environment.NewLine, data.dangkythanhcong) + "Đăng ký học phần thất bại:\n" + string.Join(Environment.NewLine, data.dangkythatbai);
                MessageBox.Show(message);
            }

           // MessageBox.Show(string.Join(Environment.NewLine, data.dangkythanhcong));

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            malop = MaLopBox.Text;
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            password = PasswordBox.Text;
        }

        private void Autofill_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(malop);
            string filePath = "setting.json";

            // Đọc tệp JSON
            string jsonContent = File.ReadAllText(filePath);

            // Giải mã JSON vào đối tượng (class) tương ứng
            MyData data = JsonSerializer.Deserialize<MyData>(jsonContent);

            // Sửa dữ liệu
            UsernameBox.Text =  data.username;
            PasswordBox.Text =  data.password;
            MaLopBox.Text = string.Join(Environment.NewLine, data.malop);
        }

        private void AutoF5_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
