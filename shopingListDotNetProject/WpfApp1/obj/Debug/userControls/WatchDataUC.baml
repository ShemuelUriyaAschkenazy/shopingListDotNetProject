   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PL.userControlsPL.userControls  5      !    PL.userControls.WatchDataUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PL.userControls     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $
��139* �6   �� 5      $	��40* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ BuyingsDataGrid��5   >   $��0��6   $
��Left=�6#      AutoGenerateColumns .     CanUserAddRows .  $��2��6�   ��6W   �� *
buyinglist+   Columns 5      4  .System.Windows.Controls.DataGridComboBoxColumn  5      -   5        ProductColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Product��5   @      DisplayMemberPath$ ProductName��6Q      SelectedValuePath$ 	ProductId��6�      
IsReadOnly . 	   ItemsSource	 6q   �� *productlist+
   SelectedValueBinding
 6�   �� *	ProductId+6�     5      -   5        StoreColumn��$ Store��5   >   $ 	StoreName��6M   $ StoreId��6�    . 	 6k   �� *	storelist+
 6�   �� *	StoreId+6�   0  *System.Windows.Controls.DataGridTextColumn  5      $ Amount��6%    . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Amount+6P     5      $ Price��6%    .  64   �� *PricePerOneProduct+6[   4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        
dateColumn��$
 Date��5   =      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6K    .    CellTemplate 5      �� 5      .R�5      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� *Date+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 5      5        5      -   5        
UserColumn��$
 User��5   =   $ UserName��6K   $ UserId��6�    . 	 6h   �� *
userlist+
 6�   �� *UserId+6�   5"      � 5#   
   -   5         �Name$ 	rightGrid��5#      $��1��6"    � RowDefinitions 5$      �� 5%      $	��67* �6    �� 5&      $
��114* �6    �� 5'      $
��269* �6    .+�5)      �� -   5        $��image��5)      $��1��6!   ��6.   �� *ProductImagePath+$ TwoWay=�5*      5+      5,      