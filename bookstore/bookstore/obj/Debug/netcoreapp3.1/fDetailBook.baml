   M S B A M L   `   `   `  ����D  @bookstore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:bookstore	bookstore  5   	       bookstore.fDetailBook   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:bookstore     5   	     � Title$  fDetailBook��5   	   $	��450��6   $	��600��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��40* �6   �� 5      $	��60* �6   .+�5   
   �� -   5         ��Name$ 	imageBook��5   )   $	��200��6   $	��320��6   $��0��6<   5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ 
tensach_LB��5       $��50��6   $��20(�64   $��Calibri)�6B   $
��Bold"�6W   $��Center=�6i   $	��193��6�   �� 5      $��0,20,0,0q�6    �� Orientation$ 
Horizontal=�6+   .+�5      �� $	��110��6   $��30��6$   $��15(�60   $
��Left=�6>   $��Tác giả : ��6Y   $��Calibri)�6n   �� 5      -   5        $ 	tacgia_LB��5      $��30��6+   $��16(�67   $
��Left=�6E   $	��Top=�6`   $��Calibri)�6x   $
��Bold"�6�   5      �� 5      $��0,20,0,0q�6   $ 
Horizontal=�6+   .+�5      �� $	��110��6   $��30��6$   $��15(�60   $
��Left=�6>   $��Nhà xuất bản : ��6Y   $��Calibri)�6s   �� 5      -   5        $ nxb_LB��5      $��30��6(   $��16(�64   $
��Left=�6B   $	��Top=�6]   $��Calibri)�6u   $
��Bold"�6�   5      �� 5      $��0,20,0,0q�6   $ 
Horizontal=�6+   .+�5      �� $	��110��6   $��30��6$   $��15(�60   $
��Left=�6>   $��Năm xuất bản : ��6Y   $��Calibri)�6s   �� 5      -   5        $ namxb_LB��5      $��30��6*   $��16(�66   $
��Left=�6D   $	��Top=�6_   $��Calibri)�6w   $
��Bold"�6�   5      �� 5      $��0,20,0,0q�6   $ 
Horizontal=�6+   .+�5      �� $	��110��6   $��30��6$   $��15(�60   $
��Left=�6>   $��Thể loại : ��6Y   $��Calibri)�6o   �� 5       -   5        $ 
theloai_LB��5       $��30��6,   $��16(�68   $
��Left=�6F   $	��Top=�6a   $��Calibri)�6y   $
��Bold"�6�   5!      �� 5"      $��0,20,0,0q�6   $ 
Horizontal=�6+   .+�5#      �� $	��110��6   $��30��6$   $��15(�60   $
��Left=�6>   $��Trạng thái : ��6Y   $��Calibri)�6q   �� 5$      -   5        $ trangthai_LB��5$      $��30��6.   $��16(�6:   $
��Left=�6H   $	��Top=�6c   $��Calibri)�6{   $
��Bold"�6�   5%      �� 5&      .+�5'      �� -   5        $ price_LB��5'   0   $	��110��6   $��50��6$   $��0,20,0,0q�6B   $��20(�6T   $
��Bold"�6b   
���  ��6�   5(      5)      5*      5+      