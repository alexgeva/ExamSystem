   M S B A M L   `   `   `  ����F  BExamsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ExamsSystem.WindowsExamsSystem.Windows  5   	   +    %ExamsSystem.Windows.StudentStatistics   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ExamsSystem.Windows     5   	     � Title$  Student Statistics��5   	   $	��835��6$   $
��1350��61    � WindowStartupLocation$ CenterScreen=�6>   .��5	      � $��
39,32,36,0q�6    � RowDefinitions 5
   
   �� 5      $	��13* �6   �� 5      $
��363* �6   .+�5   
   �� $��Center=�6   $	��819��6.   $	��Top=�6;   $
��1351��6S   ���	#FF45BBB9$��	0,-32,0,0q�6w   $��2��6�   .+�5      �� $��Student Name��6   $��36��6+    �� Left$ 52��67   
 �� Top$ 82��6H   $	��127��6X   $��16(�6d   $
��Bold"�6r   $
��Left=�6�   $��Center=�6�   $��0,0,0,2q�6�   
���   �6�   �� 5      $��Student Statistics��6   $��64��61   $	 425��6=   $ 5��6O   $	��393��6^   $��36(�6j   $
��Bold"�6x   $
��Left=�6�   ���	#FFF7F5F5���	#FFE2DBDB$��Center=�6�   $��Italic$�6�   $��0,0,0,3q�6  �� 5      -   5         ��Name$ btnExit��5      $
��Exit��6&   $��75��65   $ 28��6A   $	 699��6R   $	��146��6c   $��18(�6o   $
��Bold"�6}   ���	#FFA08A88$
��Left=�6�   $��Center=�6�   6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
STDataGrid��5      $	��529��6+   $ 14��68   $	 128��6I   $	��179��6Z   $
��Left=�6�   $��Center=�6�   4  .System.Windows.Automation.AutomationProperties   IsRowHeader$
 True��6�      
IsReadOnly$
 True��6�   $
��Bold"�6g    5      -   5        $ STDDataGrid��5      $	��529��6,   $	 209��69   $	 128��6K   $��206.5��6\   $
 True��6�   $
 True��6�   $
��Left=�6�   $��Center=�6�   $
��Bold"�66  �� 5      $��Student Exams Grade��6   $��36��62   $	 226��6>   $ 82��6P   $	��176��6`   $��16(�6l   $
��Bold"�6z   $��0,0,0,2q�6�   
���   �$
��Left=�6�   $��Center=�6�     5      -   5        $ 
SADataGrid��5      $	��529��6+   $	 430��68   $	 128��6J   $	��911��6[   $
 True��6�   $
 True��6�   $
��Left=�6�   $��Center=�6  $��10(�62  $
��Bold"�6@  �� 5      -   5        	 ��Name$	 lbl_ewa��5      $��Exam Wrong Answer��6%   $��36��6A   $	 697��6M   $ 82��6_   $	��176��6o   $��16(�6{   $
��Bold"�6�   $��0,0,0,2q�6�   
���   �$
��Left=�6�   $��Center=�6�   5      5      5      