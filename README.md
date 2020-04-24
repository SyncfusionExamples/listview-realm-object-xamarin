# How to render ListView using RealmObject in Xamarin.Forms (SfListView)

You can render Xamarin.Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview?) using the Realm object. Please follow the steps below to use the [Realm](https://realm.io/docs/dotnet/latest/#getting-started) object.

You can also refer the following article.

https://www.syncfusion.com/kb/11445/how-to-render-listview-using-realmobject-in-xamarin-forms-sflistview

**Step 1:** Install the [Realm](https://www.nuget.org/packages/Realm/) Nuget package to the shared code project.

**Step 2:**  Create a model class by inheriting [RealmObject](https://realm.io/docs/dotnet/latest/api/reference/Realms.RealmObject.html).
``` c#
namespace ListViewXamarin
{
    public class BookInfo : Realms.RealmObject
    {
        public BookInfo()
        {
 
        }
 
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookAuthor { get; set; }
    }
}
```
**Step 3:** Obtain the realm object in the model class repository using the [GetInstance](https://realm.io/docs/dotnet/latest/api/reference/Realms.Realm.html#Realms_Realm_GetInstance_Realms_RealmConfigurationBase_) method. Populate items and [add](https://realm.io/docs/dotnet/latest/api/reference/Realms.Realm.html#Realms_Realm_Add_Realms_RealmObject_System_Boolean_) them to the Realm object.
``` c#
namespace ListViewXamarin
{
    public class BookInfoRepository
    {
        Realms.Realm realm;
 
        public BookInfoRepository()
        {
            realm = Realms.Realm.GetInstance();
        }
 
        internal IEnumerable<BookInfo> GetBookInfo()
        {
            realm.Write(() =>
            {
                for (int i = 0; i < BookNames.Count(); i++)
                {
                    var book = new BookInfo()
                    {
                        BookName = BookNames[i],
                        BookDescription = BookDescriptions[i],
                        BookAuthor = BookAuthers[i],
                    };
                    realm.Add(book);
                }
            });
            return realm.All<BookInfo>().AsRealmCollection();
        }
    }
}
```
**Step 4:** Create a ViewModel collection as [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable) and set the realm collection to the ViewModel collection.
``` c#
namespace ListViewXamarin
{
    public class ViewModel
    {
        private IEnumerable<BookInfo> bookInfo;
 
        public ViewModel()
        {
            GenerateSource();
        }
 
        public IEnumerable<BookInfo> BookInfo
        {
            get { return bookInfo; }
            set { this.bookInfo = value; }
        }
 
        private void GenerateSource()
        {
            BookInfoRepository bookInfoRepository = new BookInfoRepository();
            bookInfo = bookInfoRepository.GetBookInfo();
        }
    }
}
```
**Step 5:** Bind ViewModel collection to [SfListView.ItemsSource](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemsSource.html?) and bind the model properties to the [ItemTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~ItemTemplate.html?).
``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:sync="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage">
 
    <ContentPage.BindingContext>
        <local:ViewModel />
    </ContentPage.BindingContext>
 
    <sync:SfListView x:Name="listView" AutoFitMode="Height" ItemsSource="{Binding BookInfo}" SelectionBackgroundColor="#d3d3d3">
        <sync:SfListView.ItemTemplate>
            <DataTemplate>
                <Grid Padding="0,12,8,0">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="1"/>
                    </Grid.RowDefinitions>
                    <StackLayout Orientation="Vertical" Padding="5,-5,0,0" VerticalOptions="Start" Grid.Row="0">
                        <Label Text="{Binding BookName}" FontAttributes="Bold" FontSize="16" TextColor="#000000" />
                        <Label Text="{Binding BookAuthor}" Grid.Row="1" FontSize="14"  Opacity=" 0.67" TextColor="#000000" />
                        <Label Text="{Binding BookDescription}" Opacity=" 0.54" TextColor="#000000" FontSize="13"/>
                    </StackLayout>
                    <BoxView Grid.Row="1" HeightRequest="1" Opacity="0.75" BackgroundColor="#CECECE" />
                </Grid>
            </DataTemplate>
        </sync:SfListView.ItemTemplate>
    </sync:SfListView>
</ContentPage>
```
