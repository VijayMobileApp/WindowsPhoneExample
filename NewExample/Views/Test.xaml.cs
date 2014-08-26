using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using NewExample.ViewModel;

namespace NewExample.Views
{
    public partial class Test : PhoneApplicationPage
    {
        public Test()
        {
            InitializeComponent();
            testUIContainer.DataContext = new TestViewModel();
        }
    }
}

//XAML Designs
/*
 <Grid x:Name="LayoutRoot" Background="Transparent">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>



        <!--ContentPanel - place additional content here-->
        <ScrollViewer VerticalScrollBarVisibility="Visible" MaxWidth="477">
            <ScrollViewer.Content>
                    
                    <Grid x:Name="testUIContainer" Margin="2,0,2,0">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="*"/>
                    </Grid.RowDefinitions>
                    <!--<Rectangle  Height="50" Margin="0,0,0,0" Name="Header" Stroke="Black" StrokeThickness="1" Width="480" Grid.ColumnSpan="2" Fill="#FF01A1DB" />-->
                    <ListBox ScrollViewer.VerticalScrollBarVisibility="Disabled" Grid.Row="0" ItemsSource="{Binding StudentDetails,Mode=TwoWay}" Margin="0,0,0,0" Name="listBox1" Width="476" BorderBrush="#00410D0D">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <Border BorderBrush="Gray" Padding="5" BorderThickness="1">
                                        <StackPanel Orientation="Horizontal" >
                                            <Border BorderBrush="Wheat" BorderThickness="1">
                                                <Image  Name="ListPersonImage" Source="{Binding PersonImage}" Height="100" Width="100" Stretch="Uniform" Margin="10,0,0,0"/>
                                            </Border>
                                            <TextBlock Text="{Binding FirstName}" Name="firstName" Width="200" Foreground="White" Margin="10,10,0,0" FontWeight="SemiBold" FontSize="22"  />
                                            <TextBlock Text="{Binding LastName}" Name="lastName" Width="200" Foreground="White" Margin="-200,50,0,0" FontWeight="SemiBold" FontSize="22"  />
                                            <TextBlock Text="{Binding Age}" Name="age" Width="200" Foreground="White" Margin="10,10,0,0" FontWeight="SemiBold" FontSize="22"  />
                                        </StackPanel>
                                    </Border>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                        
                        <ListBox ScrollViewer.VerticalScrollBarVisibility="Disabled" Grid.Row="1" ItemsSource="{Binding StudentDetails,Mode=TwoWay}" HorizontalAlignment="Left" Margin="0,0,0,0" Name="listBoxes1" Width="476" BorderBrush="#00410D0D">
                            <ListBox.ItemTemplate>
                                <DataTemplate>
                                    <Border BorderBrush="Gray" Padding="5" BorderThickness="1">
                                        <StackPanel Orientation="Horizontal" >
                                            <Border BorderBrush="Wheat" BorderThickness="1">
                                                <Image  Name="ListPersonImage" Source="{Binding PersonImage}" Height="100" Width="100" Stretch="Uniform" Margin="10,0,0,0"/>
                                            </Border>
                                            <TextBlock Text="{Binding FirstName}" Name="firstName" Width="200" Foreground="White" Margin="10,10,0,0" FontWeight="SemiBold" FontSize="22"  />
                                            <TextBlock Text="{Binding LastName}" Name="lastName" Width="200" Foreground="White" Margin="-200,50,0,0" FontWeight="SemiBold" FontSize="22"  />
                                            <TextBlock Text="{Binding Age}" Name="age" Width="200" Foreground="White" Margin="10,10,0,0" FontWeight="SemiBold" FontSize="22"  />

                                        </StackPanel>
                                    </Border>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                        
                </Grid>
            </ScrollViewer.Content>
        </ScrollViewer>
    </Grid>
*/