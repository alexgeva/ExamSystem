   M S B A M L   `   `   `  ����F  BExamsSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ExamsSystem.WindowsExamsSystem.Windows  5   	   *    $ExamsSystem.Windows.AddExamQuestions   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ExamsSystem.Windows     5   	     � Title$  Add Exam Question��5      $	��860��6"   $
��1340��6/    � WindowStartupLocation$ CenterScreen=�6<   .��5	      � $��
39,32,36,0q�6    � RowDefinitions 5
   
   �� 5      $	��13* �6   �� 5      $
��363* �6   .+�5   
   �� $��Center=�6   $	��844��6.   $	��Top=�6;   $
��1343��6S   ���	#FF45BB8D$��	0,-32,0,0q�6w   $��2��6�   .+�5      �� $��IdQuestionNumber��6   $��36��6/    �� Left$	 237��6;   
 �� Top$ 87��6M   $	��166��6]   $��16(�6i   $
��Bold"�6w   $
��Left=�6�   $��Center=�6�   $��0,0,0,2q�6�   
���   �6�   �� 5      -   5         ��Name$ txtIdQuestion��5      $��36��6-   $	 403��69    �� TextWrapping$
 Wrap=�6K   $ 87��6_   $��52��6o   $
��Bold"�6z   $
��Left=�6�   $��Center=�6�   $�� ��6�   �� 5      $!��Add Questions To Exams Form��6   $��64��6:   $	 315��6F   $ 5��6X   $	��555��6g   $��36(�6s   $
��Bold"�6�   $
��Left=�6�   ���	#FFF7F5F5���	#FFE2DBDB$��Center=�6�   $��Italic$�6�   $��0,0,0,3q�6  �� 5      -   5         ��Name$ btnAdd��5      $��75��6&   $	 169��62   $	 740��6D   $	��150��6U   $��18(�6a   $
��Bold"�6o   ���	#FF4183D7$��Center=�6�   $	��Top=�6�   $��Expanded&�6�   .��5      �� .+�5      �� $��	Add Temp ��6    �� 5      $��Question Exam��6    $��Normal&�65   5      5      �� 5      -   5        $ btnExit��5      $
��Exit��6&   $��75��65   $ 22��6A   $	 740��6R   $	��133��6c   $��18(�6o   $
��Bold"�6}   ���	#FFA08A88$��Center=�6�   $	��Top=�6�   6�   �� 5      -   5        $ btnEdit��5      $��75��6'   $	 330��63   $	 740��6E   $	��150��6V   $��18(�6b   $
��Bold"�6p   ���	#FF29D424$��Center=�6�   $	��Top=�6�   .��5      �� .+�5      �� $��
Edit Temp ��6    �� 5      $��Question Exam��6    5      5       &   System.Windows.Controls.DataGrid  5!      -   5          Name$ 
EXDataGrid��5!      $	��164��6+   $ 27��68   $	 140��6I   $
��1005��6Z   $
��Left=�6�   $��Center=�6�   4  .System.Windows.Automation.AutomationProperties	   IsRowHeader$
	 True��6�   
   
IsReadOnly$

 True��6�   $
��Bold"�6h  $��14(�6z  �� 5"      -   5        $ 	btnDelete��5"      $��75��6(   $	 661��64   $	 740��6F   $	��150��6W   $��18(�6c   $
��Bold"�6q   ���	#FFF57164$��Center=�6�   $	��Top=�6�   .��5#      �� .+�5$      �� $��Delete Temp ��6    �� 5%      $��Question Exam��6    5&      5'      �� 5(      $��IdExamNumber��6   $��36��6+   $ 43��67   $ 87��6H   $	��131��6X   $��16(�6d   $
��Bold"�6r   $��0,0,0,2q�6�   
���   �$
��Left=�6�   $��Center=�6�   �� 5)      -   5        $ 	txtIdExam��5)      $��31��6)   $	 177��65   $
 Wrap=�6G   $ 92��6[   $��44��6k   $��16(�6v   $
��Bold"�6�   $
��Left=�6�   $��Center=�6�    �� 
IsReadOnly$
 True��6�     5*      -   5        $ 	QDataGrid��5*      $	��407��6*   $ 27��67   $	 318��6H   $
��1005��6Y   $
	 True��6�   $

 True��6�   $
��Left=�6�   $��Center=�6    5+      -	   5        $ EXQDataGrid��5+      $	��551��6,   $
 1059��69   $	 174��6L   $	��111��6]   $
	 True��6�   $

 True��6�   $
��Left=�6�   $��Center=�6  $��18(�64  $
��Bold"�6B  6T  �� 5,      $��Question count��6   $��36��6-   $	 793��69   $ 87��6K   $	��126��6[   $��16(�6g   $
��Bold"�6u   $��0,0,0,2q�6�   
���   �$
��Left=�6�   $��Center=�6�   �� 5-      -
   5        $ txtCount��5-      $��36��6(   $	 924��64   $
 Wrap=�6F   $ 87��6Z   $��50��6j   $
��Bold"�6u   $�� ��6�   $
��Left=�6�   $��Center=�6�    J� RenderTransformOrigin$ 0.815,0.441&�6�   �� 5.      -   5        $ btnClear��5.      $��
Clear Data��6'   $��37��6<   $	 673��6H   $ 86��6Z   $��99��6j   $��18(�6u   $
��Bold"�6�   ���	#FFA08A88$
��Left=�6�   $��Center=�6�   6�   �� 5/      $��Num of Questions��6   $��36��6/   $	 474��6;   $ 84��6M   $	��151��6]   $��16(�6i   $
��Bold"�6w   $��0,0,0,2q�6�   
���   �$
��Left=�6�   $��Center=�6�   �� 50      -   5        $ txtINumOfQuestion��50      $��31��61   $	 630��6=   $
 Wrap=�6O   $ 89��6c   $��34��6s   $��16(�6~   $
��Bold"�6�   $
 True��6�   $
��Left=�6�   $��Center=�6�   �� 51      -   5        $ btnAdd_Random��51      $��75��6-   $	 492��69   $	 740��6K   $	��160��6\   $��18(�6h   $
��Bold"�6v   ���	#FFD8C81E$��Center=�6�   $	��Top=�6�   .��52      �� .+�53      �� $��Add Temp��6    �� 54      $��Random Question��6    55      56      �� 57      -   5        $ btnSave��57      $��	Save Exam��6&   $��75��6:   $	 824��6F   $	 740��6X   $	��143��6i   $��24(�6u   $
��Bold"�6�   ���	#FF87CAAA$��Center=�6�   $	��Top=�6�   ${�False��6�     58      -   5        $ EXQDataGridReal��58      $	��551��60   $
 1197��6=   $	 174��6P   $	��111��6a   $
	 True��6�   $

 True��6�   $��18(�6�   $
��Bold"�6�   $
��Left=�6�   $��Center=�6  6(  �� 59      $��
TEMP TABLE��6   $��36��6)   $
 1062��65   $	 133��6H   $	��105��6Y   $��16(�6e   $��0,0,0,2q�6s   
���   �$
��Left=�6�   $��Center=�6�   $
��Bold"�6�   �� 5:      $��
REAL TABLE��6   $��36��6)   $
 1201��65   $	 133��6H   $	��118��6Y   $��16(�6e   $��0,0,0,2q�6s   
���   �$
��Bold"�6�   $
��Left=�6�   $��Center=�6�   5;      5=      5>      