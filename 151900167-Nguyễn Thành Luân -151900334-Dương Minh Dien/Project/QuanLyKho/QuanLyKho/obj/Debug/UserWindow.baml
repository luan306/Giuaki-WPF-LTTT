   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   G(clr-namespace:QuanLyKho.UserControlKteamQuanLyKho.UserControlKteam  5	   
       QuanLyKho.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   7uc(clr-namespace:QuanLyKho.UserControlKteam     5	   
   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5   	   $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    
 UserVM � DataContext# [ 5       � Title$ Người Dùng��5   	   $	��500��6   $	��700��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   �� 	 �� CornerRadius$	 10��6   $��2��6#   ��5      �� 5       .��5!      � 
 � Color$
 #7be9f6��6#    � Offset$	 0.0Q�63   � 5"      $
 #f083da��6#   $ 1Q�63   5#      5%      � 5&   
   $��0��6   .+�5'      -   'QuanLyKho.UserControlKteam.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ window��6J   5(      � 5*   
   $��1��6    5+      �� 5,      $
��auto �6    60   �� 5-      $
��auto �6    60   �� 5.      6"   .+�52      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��53      � $��0 0 0 10q�6   .+�54      �� $��5 5 15 5q�6i   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��6{    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 55      $��5 5 15 5q�6l   $ Quyền��6~   #��[ 6�   ��6   �� *DisplayName+$ PropertyChanged=�$ TwoWay=�6�   58      59        5;      $��1��6"   $��5q�6/   .��5<      � .+�5=      �� $��Thêm��6<   $��5q�6K   $	��100��6V   ��6   �� *
AddCommand+6d   �� 5>      $��Sửa��6=   $��5q�6L   $	��100��6W   ��6   �� *EditCommand+6e   �� 5?      $��Xóa��6?   $��5q�6N   $	��100��6Y   ��6   �� *DeleteCommand+6g   5A      5B        5D      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5E      �� $
��Auto=�6   .��5F      �� ��6   �� *List+ �� SelectedItem 6<   �� *SelectedItem+$ OneWayToSource=� �� View 5G      �� 5H      .P�5I   "   �� $��Id��61    �� DisplayMemberBinding 6=   �� *Id+6c   �� 5J   "   $��Tên đăng nhập��61    6I   �� *
UserName+6u   �� 5K   "   $��Quyền��61    6@   �� *DisplayName+6o   5N      5P      5Q      5R      5S      5T      5U      