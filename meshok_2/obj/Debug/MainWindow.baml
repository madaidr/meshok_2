   M S B A M L   `   `   `  ����H  Dmeshok_number, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:meshok_2meshok_2  5   	       meshok_2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:meshok_2     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��600��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ button��5
      $��
Войти��6!   $
��Left=�61   $��33,8,0,0q�6L   $	��Top=�6^   $	��140��6v   $��29��6�   6�   �� 5   
   -   5        $ button1��5      $%��Выгрузить ссылки��6"   $
��Left=�6=   $��	33,51,0,0q�6X   $	��Top=�6k   $	��140��6�   $��29��6�   6�   �� 5   
   -   5        $ button2��5      $*��$Исправить в таблице��6"   $
��Left=�6@   $��	33,93,0,0q�6[   $	��Top=�6n   $	��140��6�   $��29��6�   6�   �� 5   
   -   5         ��Name$ listBox1��5      $
��Left=�6$   $	��112��6?   $��
203,34,0,0q�6L   $	��Top=�6`   $	��362��6x   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $	��191��6@   $��
10,168,0,0q�6M   $	��Top=�6a   $	��562��6y      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Описание��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$	 252 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Text+6P   5  /System.Windows.Controls.DataGridHyperlinkColumn  5      $	 URL��6D   $	 302 6Q    6*   �� *GoURL+	   ElementStyle	 5      �� 5      .�5      -   5        5      5      5      �� 5   
   -   5        $ button3��5      $(��"Исправить на сайте��6"   $
��Left=�6?   $��
33,134,0,0q�6Z   $	��Top=�6n   $	��140��6�   $��29��6�   6�   5      5      