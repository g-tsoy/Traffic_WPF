   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   B >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1 5   	      WpfApp1.GetTimeWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  GetTimeWindow��5	   	   $	��250��6   $	��450��6,   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6   �� 5      $��5* �6   .+�5   
   �� $��15 1 1 1q�5   3   $��Center=�6G   $
��Left=�6b   $��16(�6~   $��Arial)�6�   $��2��6�   $��0��6�   $��0��6�   ��5      �� 
 �� Now �� Source# Z  �� StringFormat$ {0:dddd, MMMM dd, yyyy}��5   �   �� 5   
   $��	15 1 30 1q�5   (   $��Center=�6=   $��Right=�6X   $��24(�6u   $��Arial)�6�   $��2��6�   $��2��6�   $��0��6�   ��5      �� # Z $ {0:HH:mm:ss}��5   �   �� 5   
   -   5        $��listBoxStation��5   ^   $��
75 0 75 10q�6   $��
15 20 15 0q�6(   $��20(�6=   $��Arial)�6K    �� DisplayMemberPath$  ��6t   $��2��6�   $��1��6�   $��0��6�   6�   �� 5   
   $��Route:��6   $��16(�6"   $��Arial)�60   $��Center=�6C   $��Bottom=�6`   $��0��6{   $��1��6�   $��	10 0 10 5q�6�   �� 5    
   $��Distination:��6   $��16(�6(   $��Arial)�66   $��Center=�6I   $��Bottom=�6f   $��1��6�   $��1��6�   $��	10 0 10 5q�6�   �� 5!   
   $��Minutes:��6   $��16(�6$   $��Arial)�62   $��Center=�6E   $��Bottom=�6b   $��2��6}   $��1��6�   $��	10 0 10 5q�6�   �� 5#   
   -   5        $��listBoxTimeToNextBus1��5#   I   $��
10 0 10 10q�6   $��14(�6(   $��Arial)�66   $ 	RouteName��6f   $��1��6�   $��0��6�   $��2��6�   6�   �� 5$   
   -   5        $��listBoxTimeToNextBus2��5$   I   $��
10 0 10 10q�6   $��14(�6(   $��Arial)�66   $
 Name��6f   $��1��6   $��1��6�   $��2��6�   6�   �� 5%   
   -   5        $��listBoxTimeToNextBus3��5%   I   $��
10 0 10 10q�6   $��14(�6(   $��Arial)�66   $
 Wait��6f   $��1��6   $��2��6�   $��2��6�   6�   �� 5'   
   $��3��6   $��2 0 5 10q�6%   $��2��68   $��Bottom=�6E   .+�5(      �� -   5        $��Cancel��5(      $��Cancel��6#   $��4 0 4 0q�64   6E   5)      5+      5,      