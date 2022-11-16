using CommunityToolkit.Mvvm.ComponentModel;
using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.ObjectModel;

namespace FriendOrganizer.UI.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public string Greeting => "Welcome to Avalonia!";

        public MainWindowViewModel(IFriendDataService friendDataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = friendDataService;
            LoadAsync();
        }

        public void LoadAsync()
        {
            var friends = _friendDataService.GetItems();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(friend);
            }
        }

        public ObservableCollection<Friend> Friends { get;set; }

        private IFriendDataService _friendDataService;

        [ObservableProperty]
        private Friend selectedFriend;
    }

}
