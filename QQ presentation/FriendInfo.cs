﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QQ_presentation
{
    public class FriendInfo:INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Signature { get; set; }
        private int _onlinestatus = 0;
        public int OnlineStatus
        {
            get { return _onlinestatus; }
            set { _onlinestatus = value; NotifyPropertyChange("OnlineStatus"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChange(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
        public int GroupID { get; set; }
    }


    public class GroupInfo : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ObservableCollection<FriendInfo> Children { get; set; }
        public GroupInfo()
        {
            this.Children = new ObservableCollection<FriendInfo>();
        }
        private int _online = 0;
        public int OnlineFriendNum
        {
            get { return _online; }
            set { _online = value; NotifyPropertyChange("OnlineNum"); }
        }
        private int _totalnum = 0;
        public int TotalFriendNum
        {
            get { return _totalnum; }
            set { _totalnum = value; NotifyPropertyChange("TotalNum"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChange(string propertyName)
        {
              if(PropertyChanged!=null)
              {
                   PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
              }
        }
    }

    public class Test
    {
        public static ObservableCollection<GroupInfo> GetGroupList()
        {
            ObservableCollection<GroupInfo> GroupList = new ObservableCollection<GroupInfo>();


            GroupInfo g = new GroupInfo() { ID = 1, Name = "My Device" };
            FriendInfo f = new FriendInfo() { Name = "My Android Phone", GroupID = 1, OnlineStatus = 1, Signature = "last log in:2015-12-30" };
            GroupList.Add(g);


            GroupInfo g1 = new GroupInfo() { ID = 1, Name = "My Friends" };
            for(int i=0; i<20; i++)
            {
                FriendInfo f1 = new FriendInfo() { Name = "Friend" + i, GroupID = 1, OnlineStatus = 2,Signature="I love English." };
                g1.Children.Add(f1);
                g1.TotalFriendNum++;
                g1.OnlineFriendNum++;
            }
            GroupList.Add(g1);


            GroupInfo g2 = new GroupInfo() { ID = 1, Name = "My Classmates" };
            for(int  i=0; i<25; i++)
            {
                FriendInfo f2 = new FriendInfo() { Name = "Classmate" + i, GroupID = 1, OnlineStatus = 2,Signature="I love English." };
                g2.Children.Add(f2);
                g2.TotalFriendNum++;
                g2.OnlineFriendNum++;
            }
            GroupList.Add(g2);


            return GroupList;
        }
    }

}
