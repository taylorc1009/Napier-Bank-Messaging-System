﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer
{
    public partial class MessagesListItem : UserControl
    {
        public DateTime messageDate { get; set; }
        public String messageID { get; set; }

        //use the parameters to push the text to the UI
        public MessagesListItem(string id, string sender, string sub, string breif, DateTime dateTime, char header)
        {
            InitializeComponent();
            
            messageID = id;
            head.Text = sender;

            //the subject is collapsed unless the message is an email
            if (sub != null)
            {
                subject.Text = sub;
                subject.Visibility = Visibility.Visible;
                //grid.RowDefinitions.ElementAt(grid.Children.IndexOf(type)).
                //grid.Children[grid.Children.IndexOf(type)].
                //type.SetValue(Grid.RowSpanProperty, 4);
            }

            body.Text = breif;
            messageDate = dateTime;
            date.Text = messageDate.ToString("HH:mm dd/MM/yy");

            /* Was going to be used to add an ListItem icon
            
            switch(header)
            {
                case 'S':
                    type.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/image-cache/sms.png", UriKind.Relative));
                    break;
                case 'E':
                    type.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/image-cache/email.png", UriKind.Relative));
                    break;
                case 'T':
                    type.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/image-cache/twitter.png", UriKind.Relative));
                    break;
            }*/
        }
    }
}
