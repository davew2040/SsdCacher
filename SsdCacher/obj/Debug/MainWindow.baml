   M S B A M L   `   `   `  ����D  @SsdCacher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SsdCacher	SsdCacher  5   	   O,clr-namespace:SsdCacher.Code.ValueConvertersSsdCacher.Code.ValueConverters  5   	   O,clr-namespace:SsdCacher.Code.ValidationRulesSsdCacher.Code.ValidationRules  5   	       SsdCacher.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SsdCacher     5   	   Hvalueconverters,clr-namespace:SsdCacher.Code.ValueConverters     5   	   Hvalidationrules,clr-namespace:SsdCacher.Code.ValidationRules     5   	   -   5          �Name$  
mainWindow��5
   	    � Title$ 
SSD Cacher��5   	   $	��600��6   $	��800��6)    � DataContext 5   	   ��  �� ElementName$ 
mainWindow�� �� Path$ AppViewModel� � 	Resources 5      9   3SsdCacher.Code.ValueConverters.CachedLabelConverter   CachedLabelConverterC   =SsdCacher.Code.ValueConverters.CachedBackgroundColorConverter " CachedBackgroundColorConverter;   5SsdCacher.Code.ValueConverters.BoolInversionConverter  BoolInversionConverter6   0SsdCacher.Code.ValueConverters.CanCacheConverter  CanCacheConverter8   2SsdCacher.Code.ValueConverters.CanUncacheConverter  CanUncacheConverter<   6SsdCacher.Code.ValueConverters.NotNullBooleanConverter  NotNullBooleanConverter��%�   &	        &	      &	 &     &	 9     &	 L     &	 _       5   
   6/     5   
   69     5   
   61     5   
   6,     5   
   6.     5   
   62   5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $��* �6   6)   �� 5      $��20 �6   6*   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   .+�5       �� $��	SSD Path:��6   �� 5!      $��10,3,0,5q�6   $	��300��6,   $��20��68   .��6D   ��5"      �� 5#      $ SsdPath�6"    �� ValidationRules 5$      4   .SsdCacher.Code.ValidationRules.ValidateSsdPath  5%   "   5'      .��5(   $   5)      �� 5*      -   5        	 ��Name$	 btn_findSsdPath��5*      $
��10,5q�6P   $��35��6^   .��6i   Find6o   5+      5,      � 5.   
   $��1��6   .+�5/      &   System.Windows.Controls.DataGrid  $
��0,10q�50      
�������
   RowBackground

 �����   AlternatingRowBackground
 ��ح�   AutoGenerateColumns .     
IsReadOnly . ��51      �� *GameEntries+ �� SelectedItem 57      �� *SelectedGameEntry+ �� Mode$ TwoWay=� � ContextMenu 59      �� 5:      .@�5;      m� -   5        $��Cache��5;   #   {�5<      `� 5=   "    `� 	Converter# [ 6/   .1�5>   &   �� $ IsBusy�6.   �� 5?   &   $ SelectedGameEntry�6.   �� 5@   &   $  SelectedGameEntry.IsCached�6.   5A   #   5C      m� 5D      -   5        $��Uncache��5D   #   {�5E      `� 5F   "   # [ 6/   .1�5G   &   �� $ IsBusy�6.   �� 5H   &   $ SelectedGameEntry�6.   �� 5I   &   $  SelectedGameEntry.IsCached�6.   5J   #   5L      �� 5M      m� 5N      -   5        $��Add Game��5N   #   65   m� 5O      -   5        $��	Edit Game��5O   #   {�66   �� *SelectedGameEntry+ �� 	Converter# [ 6�   5P         Columns 5S      0	  *System.Windows.Controls.DataGridTextColumn	  5T      ,
  &System.Windows.Controls.DataGridColumn 
  MinWidth$	 125Q�6U    
  Header$ Title��6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� $ OneWay=�$ Title�6d   	  5U      $	 150Q�6R   $ Target Directory��6a    6)   �� $ TargetDirectory�6a   	  5V       
  Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6M   $ Source Path��6W    6)   �� $ 
SourcePath�6W   	  5W      $ 75Q�6|    
  MaxWidth$ 75Q�6�   $ Cached?��6�    6)   �� $ IsCached�# [   
  	CellStyle 5X      �� 5Y       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6$   .�5Z   "   ��  �� Property � �� �� Value 6?   �� *
IsCached+# [ 5[   #   5\      5^      5`      5a      � 5c   
   $��2��6   .+�5d      �� .@�5e      �� .��5f      �� -   5        $��lblCursorPosition��5f       ��69   �� *
StatusText+5g      5h      5i      5k      5l      