   M S B A M L   `   `   `  ���� D  @SsdCacher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SsdCacher	SsdCacher  O,clr-namespace:SsdCacher.Code.ValueConvertersSsdCacher.Code.ValueConverters  O,clr-namespace:SsdCacher.Code.ValidationRulesSsdCacher.Code.ValidationRules      SsdCacher.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:SsdCacher     Hvalueconverters,clr-namespace:SsdCacher.Code.ValueConverters     Hvalidationrules,clr-namespace:SsdCacher.Code.ValidationRules     -     �Name$  
mainWindow�� � Title$ 
SSD Cacher��$	��600��$	��800�� � DataContext ��  �� ElementName$ 
mainWindow�� �� Path$ AppViewModel� � 	Resources 9   3SsdCacher.Code.ValueConverters.CachedLabelConverter   CachedLabelConverterC   =SsdCacher.Code.ValueConverters.CachedBackgroundColorConverter " CachedBackgroundColorConverter;   5SsdCacher.Code.ValueConverters.BoolInversionConverter  BoolInversionConverter6   0SsdCacher.Code.ValueConverters.CanCacheConverter  CanCacheConverter8   2SsdCacher.Code.ValueConverters.CanUncacheConverter  CanUncacheConverter<   6SsdCacher.Code.ValueConverters.NotNullBooleanConverter  NotNullBooleanConverter��%Z   &	        &	      &	 
     &	      &	      &	                  .���  � RowDefinitions �� $��30 ��� $��* ��� $��20 �.+�� $��0��.+���  �� Orientation$ 
Horizontal=�$	��Top=�.+��� $��	SSD Path:���� $��10,3,0,5q�$	��300��$��20��.������ $ SsdPath� �� ValidationRules 4   .SsdCacher.Code.ValidationRules.ValidateSsdPath  .���� -   	 ��Name$	 btn_findSsdPath��$
��10,5q�$��35��.��Find� $��1��.+�&   System.Windows.Controls.DataGrid  $
��0,10q�
�������
   RowBackground

 �����   AlternatingRowBackground
 ��ح�   AutoGenerateColumns .     
IsReadOnly . ���� *GameEntries+ �� SelectedItem �� *SelectedGameEntry+ �� Mode$ TwoWay=� � ContextMenu �� .@�m� -   $��Cache��{�`�  `� 	Converter# [ .1��� $ IsBusy��� $ SelectedGameEntry��� $  SelectedGameEntry.IsCached�m� -   $��Uncache��{�`� # [ .1��� $ IsBusy��� $ SelectedGameEntry��� $  SelectedGameEntry.IsCached��� m� -   $��Add Game��m� -   $��	Edit Game��{��� *SelectedGameEntry+ �� 	Converter# [    Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  MinWidth$	 125Q� 
  Header$ Title��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $ OneWay=�$ Title�	  $	 150Q�$ Target Directory�� �� $ TargetDirectory�	   
  Width5  /System.Windows.Controls.DataGridLengthConverter$ * $ Source Path�� �� $ 
SourcePath�	  $ 75Q� 
  MaxWidth$ 75Q�$ Cached?�� �� $ IsCached�# [   
  	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value �� *
IsCached+# [ � $��2��.+��� .@��� .���� -   $��lblCursorPosition������ *
StatusText+