   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      = 9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PL.userControlsPL.userControls 5      $   PL.userControls.DataSectionsUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      /localclr-namespace:PL.userControls     5      .��5
      �   � RowDefinitions  5   
   �� 5      $��2* �6   �� 5      $��5* �6   .+�5   
   #   LiveCharts.Wpf.CartesianChart  -   5        $��chart��5      &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6N   $��6��6e   $��1��6y      Series 6*   �� *SeriesCollection+   AxisY 5         LiveCharts.Wpf.Axis  -   5        $��
chartAxisY��5         Title$ Amount��6-   6>      AxisX 5        -   5        $��
chartAxisX��5      $ Month��6-      Labels 6;   �� *Labels+6W   5      � 5   
     5      �� 5      $��* �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5       $��* �6#   �� 5!      $��* �6#   �� 5"      $��* �6#   �� 5#      $��* �6#   �� 5$      $��2* �6#   .+�5&      �� $��Center=�6   $
��Wrap=�66   $��
Data Type:��6J   $��Center=�6\   �� 5'      -   5        $��DataTypeSelection��5'      $
��Left=�60   $��23��6K    �� Text$ TextBox��6Y   $��Center=�6h   $��70��6�   $��1��6�   .@�5(      �� -   5        $��Product��5(      	 �� 
IsSelected	 . .��6@   	product6I   �� 5)      -   5        $��Store��5)      .��6,   store63   �� 5*      -   5        $��Category��5*      .��6/   
category69   �� 5+      -   5        $��	TotalCost��5+      .��60   
total cost6<   5,      �� 5-      $��Center=�6   $
��Wrap=�66   $��
Parameter:��6J   $��Center=�6\   $��2��6w   �� 5.      -	   5        $��parameterCB��5.      
 �� DisplayMemberPath$
 ProductName��6N   $
��Left=�6n   $��23��6�   $ TextBox��6�   $��Center=�6�   $	��120��6�   $��3��6�   ��6*   �� *productlist+6�   �� 5/      $��Center=�6   $
��Wrap=�66   $��Scaling:��6J   $��Center=�6Z   $��4��6u   �� 50      -
   5        $��	scalingCB��50      $
��Left=�6(   $��23��6C   $ TextBox��6P   $��Center=�6_   $��70��6z   $��5��6�   52      �� 53      -   5         ��Name$ timeFirstLabel��53      $��Center=�6,   $��Month:��6I   $��Center=�6Z   $��1��6u   $��2��6�   �� 54      -   5         ��Name$ timeFirstCB��54      $
��Left=�6,   $��23��6G   $��Center=�6U   $��50��6p   $��3��6{   $��1��6�   �� 55      -   5        $ timeSecondLabel��55      $��Year:��6/   $��Center=�6?   $��1��6[   $��4��6h   $��Center=�6x   �� 56      -   5        $ timeSecondCB��56      $
��Left=�6.   $��23��6I   $��Center=�6W   $��50��6r   $��1��6}   $��5��6�   �� 57      $
��view��6   $��6��6$   $��Center=�64   $��50��6Q   $��2��6^   $��Center=�6o   $��88��6�   ��6�   �� *viewGraphAction+��6�   ��  �� ElementName$ timeSecondCB�� �� Path$ SelectedItem�59      5:      5;      5<      