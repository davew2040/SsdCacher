   M S B A M L   `   `   `  ����D  @SsdCacher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SsdCacher	SsdCacher  5   	   )    #SsdCacher.Dialogs.AddEditGameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SsdCacher     5   	     � Title$  AddEditGame��5   	   $	��175��6   $	��300��6*    � 
ResizeMode$ NoResize=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Center=�6-   .��6H   Title:6P   �� 5   
   $��1��6   $��0��6   $��Center=�6-   .��6H   Source Path:6V   �� 5   
   $��2��6   $��0��6!   $��Center=�61   $��5,0,0,0q�6L   Target�� 6d   
Directory:6{   �� 5   
   $��0��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5      �� $
��Left=�6:   $	��150��6U   $��25��6a   ��6   �� *Title+ �� Mode$ TwoWay=�6a   5      �� 5   
   $��1��6   $��1��6"   $ 
Horizontal=�62   .+�5      �� $
��Left=�6?   $	��150��6Z   $��25��6f   ��6   �� *
SourcePath+$ TwoWay=�6f   �� 5      -   5        $
��10,5q�5   2   $��35��6@   .��6K   Find6Q   5       �� 5"   
   $��2��6   $��1��6"   $ 
Horizontal=�62   .+�5#      �� $
��Left=�6D   $	��150��6_   $��25��6k   ��6   �� *TargetDirectory+$ TwoWay=�6k   5$      �� 5&   
   -   5         ��Name$ btn_Done��5&      $��3��6#   $��0��60   $��2��6@   $��75��6T   $��0,0,0,0q�6_   $��30��6p   .��6�   Add6�   5'      5(      