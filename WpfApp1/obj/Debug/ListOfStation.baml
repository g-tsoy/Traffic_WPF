   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.ListOfStation   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   �� .@�5      �� $��List of Routes��6   .��5      �  � ColumnDefinitions 5      �� 5      $	��31* �6+   �� 5      $
��108* �6+   �� 5      $
��246* �6+   �� 5      $
��128* �6+   .+�5      �� -   5        $��listBoxStations��5   1   $��	2,2,1.8,2q�6    �� DisplayMemberPath$
 Name��6H   $��3��6a   5      �� 5      $��3��6!   $��2.2,2,1.8,2q�61   .+�5      �� -   5        $��Get_Time��5   !   $��GetTime��61   $��	4 10 4 10q�6C   6V   �� 5      -   5        $	��Add��5   !   $��Add to Favourites��6,   $��4 5 4 10q�6H   6Z   5      �� 5      $��3��6!   $��2.2,2,1.8,2q�61   5      5      5      �� 5      $��Favourite stations��6   .��5      � $
��Left=�6   $��0,0,-0.2,-0.4q�62   $	��513��6I    5       �� 5!      $	��19* �6+   �� 5"      $	��18* �6+   �� 5#      $
��347* �6+   �� 5$      $
��129* �6+   .+�5&      �� -   5        $��listBoxFavouritesStations��5&   3   $��2,2,1.8,1.4q�6   $
 Name��6T   $��4��6m   5'      �� 5(      $��3��6!   $��2,2,1.8,1.4q�61   .+�5)      �� -   5        $��Get_Time_Favourites��5)   !   $��GetTime��6<   $��	4 10 4 10q�6N   6a   �� 5*      -   5        $��Delete��5*   !   $��Delete��6/   $��4 5 4 10q�6@   6R   �� 5+      -   5        $
��Exit��5+   !   $
��Exit��6-   $��4 5 4 10q�6<   6N   5,      5-      5.      5/      50      51      