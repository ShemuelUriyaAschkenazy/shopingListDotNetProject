   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PL.userControlsPL.userControls  5      $    PL.userControls.RecentBuyingUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:PL.userControls     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��503* �6   �� 5      $
��297* �6    � RowDefinitions 5   
   �� 5      $	��27* �6   �� 5      $	��46* �6   �� 5      $
��377* �6   .+�5   
   �� -   5         ��Name$ addData��5      $��1��6"   $0��*שמור בהיסטוריית הקניות��6/   $��0��6�   $
��Auto��6�   $
��Auto��6�   ��6P   �� *
SaveAction+��6o   ��  �� ElementName$ ConfirmCheckBox�� �� Path$ 	IsChecked�6�   �� 5   
   -   5         ��Name$ ConfirmCheckBox��5      $6��0אני מאשר את נכונות הנתונים��6,   $��RightToLeft=�6Q   $��1��6m   $��Center=�6}   $��Center=�6�   $��1��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��recentBuyingsDataGrid��5         AutoGenerateColumns .     CanUserAddRows .  $��2��6�   $��2��6�   $��0,0.333,0,0q�6�   ��60   �� *RecentBuyingList+ �� Mode$ TwoWay=�	   Columns	 5      4  .System.Windows.Controls.DataGridComboBoxColumn  5      -   5        ProductColumn��,  &System.Windows.Controls.DataGridColumn
   Header$
 Product��5   @      DisplayMemberPath$ ProductName��6Q      SelectedValuePath$ 	ProductId��6�      ItemsSource 6q   �� *productlist+$ TwoWay=�   SelectedValueBinding 6�   �� *	ProductId+6�     5      -   5        StoreColumn��$
 Store��5   >   $ 	StoreName��6M   $ StoreId��6�    6k   �� *	storelist+$ TwoWay=� 6�   �� *	StoreId+6�   0  *System.Windows.Controls.DataGridTextColumn  5      $
 Amount��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Amount+$ TwoWay=�  5      $
 Price��6%    64   �� *PricePerOneProduct+$ TwoWay=�4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        
dateColumn��$

 Date��5   =      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6K      CellTemplate 5      �� 5      .R�5      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� *Date+$ TwoWay=� �� NotifyOnTargetUpdated .  �� NotifyOnSourceUpdated .  �� NotifyOnValidationError .  �� ValidatesOnExceptions . 5       5"        5#      -   5        
UserColumn��$

 User��5#   =   $ UserName��6K   $ UserId��6�    6h   �� *
userlist+$ TwoWay=� 6�   �� *UserId+6�   5'      �� 5(   
   -   5         ��Name$ topTB��5(      $��Right=�6#   $
��Wrap=�6?   $J��Dכאן ניתן לערוך את הנתונים ולשמור אותם��6S   $��Oblique$�6�   $��Center=�6�   5*      5+      