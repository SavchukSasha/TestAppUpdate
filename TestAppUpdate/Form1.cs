using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace TestAppUpdate
{
    public partial class Form1 : Form
    {
        private string fileUrl = "https://example.com/file.txt"; // Замініть на URL файлу, який ви хочете завантажити

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи користувач обрав місце для збереження файлу
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Запускаємо процес завантаження
                DownloadFile(fileUrl, saveFileDialog1.FileName);
            }
        }

        private void DownloadFile(string url, string destination)
        {
            using (var client = new WebClient())
            {
                // Встановлюємо прогрес-обработчики
                client.DownloadFileCompleted += DownloadFileCompleted;
                client.DownloadProgressChanged += DownloadProgressChanged;

                try
                {
                    // Завантаження файлу
                    client.DownloadFileAsync(new Uri(url), destination);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження файлу: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("Файл завантажено успішно!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Помилка завантаження файлу: " + e.Error.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Оновлюємо стан прогресу, якщо потрібно
            // int progress = e.ProgressPercentage;
        }
    
    
    }
}
