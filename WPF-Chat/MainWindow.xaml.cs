using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Image = System.Windows.Controls.Image;

namespace WPF_Chat;

#nullable disable

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	List<string> messages = new List<string>
	{
		"Hi",
		"I am Dylan O'brien",
	};

	private void txB_main_LostFocus(object sender, RoutedEventArgs e)
	{
		if (string.IsNullOrEmpty(txB_main.Text))
		{
			txB_second.Visibility = Visibility.Visible;
			txB_main.Visibility = Visibility.Collapsed;
		}
	}

	private void txB_second_GotFocus(object sender, RoutedEventArgs e)
	{
		txB_second.Visibility = Visibility.Collapsed;
		txB_main.Visibility = Visibility.Visible;
	}

	private void btn_send_Click(object sender, RoutedEventArgs e)
	{
		if (txB_main.Text.Length != 0)
		{
			Chat chat = new Chat();
			chat.txtblock.Text = txB_main.Text;
			chat.grid_chat.Margin = new Thickness(400, 20, 0, 0);
			chat.border.Background = new SolidColorBrush(Colors.Purple);
			chat.border.HorizontalAlignment = HorizontalAlignment.Right;
			chat.lbl_time.Content = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
			listbox.Items.Add(chat);
			txB_main.Text = null;
			Message();
		}
	}

	Image image;
	int count1 = 0;
	Random random = new Random();
	private void Message()
	{
		int count = random.Next(1, 5);
		count1++;
		string sentences = String.Join(" ", "hnhnhnhnhnhnhnhnhnhn");
		Chat chat = new Chat();

		if (count1 > 2)
			chat.txtblock.Text = sentences;
		else
			chat.txtblock.Text = messages[count1 - 1];

		chat.grid_chat.Margin = new Thickness(10, 30, 0, 0);
		chat.border.Background = new SolidColorBrush(Colors.Black);
		chat.lbl_time.Content = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
		chat.lbl_time.HorizontalAlignment = HorizontalAlignment.Left;
		listbox.Items.Add(chat);
		count = 0;
	}
}