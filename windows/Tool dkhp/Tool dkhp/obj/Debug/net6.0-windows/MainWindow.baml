   M S B A M L   `   `   `  ����D  @Tool dkhp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Tool_dkhp	Tool_dkhp  5   	       Tool_dkhp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Tool_dkhp     5   	     � Title$&   Tool đăng ký học phần UIT��5   	   $	��450��6+   $	��800��68   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      �� 5      $��0* �6   .+�5   
   �� $��2��6   $&�� TOOL ĐĂNG KÝ HỌC PHẦN UIT��6    $��Center=�6D   $��0,98,0,0q�6a   $	��Top=�6s   $��26��6�   $	��180��6�   �� 5   
   -   5         ��Name$ UsernameBox��5      $��2��6'   $��Center=�67   $��	0,151,0,0q�6T    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��120��6�   $��18��6�   6�   �� 5   
   -   5        $��2��5      $��
Đăng ký��6!   $��Center=�63   $��	0,379,0,0q�6P   $	��Top=�6c   $	��280��6{   $��20��6�   6�   �� 5   
   -   5        $ MaLopBox��5      $��Center=�6$   $��	0,276,0,0q�6A   $ WrapWithOverflow=�6T   $	��Top=�6t   $	��210��6�   $��71��6�   $��2��6�   6�   �� 5   
   -   5        $ PasswordBox��5      $��Center=�6'   $��	0,187,0,0q�6D   $
 Wrap=�6W   $��Password��6k   $	��Top=�6{   $	��120��6�   $��2��6�   6�   �� 5   
   $7��1Mã lớp muốn đăng ký (Mỗi lớp 1 dòng)��6   $��Center=�6?   $��	0,248,0,0q�6\   $	��Top=�6o   $��2��6�   �� 5   
   -   5         ��Name$ Autofill��5      $��Tự động điền��6#   $��Center=�6:   $��	0,221,0,0q�6W   $	��Top=�6j   $��76��6�   $��2��6�   6�   �� 5   
   $��Center=�6   $��48��6-   $��0,23,0,0q�69   $	��Top=�6K   $��48��6c   $��	/logo.png��6n   $��2��6�   �� 5   
   -   5         ��Name$ AutoF5��5      $��Auto F5��6#   $��3��65   $
��Left=�6I   $��363,354,0,0q�6d   $	��Top=�6y    � ToolTip$\ VTự động refresh trang liên tục cho đến khi đăng ký được học phần��6�    d� 	IsChecked$
 TrueY�6�    J� RenderTransformOrigin$ 
3.528,1.95&�6�   6  5      5      