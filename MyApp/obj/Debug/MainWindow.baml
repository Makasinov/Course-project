   M S B A M L   `   `   `  ����@  <MyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyAppMyApp  5   	       MyApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MyApp     5   	   -   5          � Title$  Демо��5   	   $	��520��6   $	��785��6#    � WindowStyle$
 None=�6/   $	��785��6B   $	��520��6Q    � WindowStartupLocation$ CenterScreen=�6}   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      .+�5   
   � -   5        $��34��5      $	��Top=�6   ���	#FFBFBFBF$��0,-3,-3.6,0q�6y   .+�5      �� -   5        $��closeButton��5      $��23��6'   $��0,4,4,0q�63   $	��Top=�6D   $��icons/error.png��6\   $��Right=�6�   $��23��6�   �� 5      -   5        $��rights��5      $��Статус��6"   $��	177,3,0,0q�63   $	��Top=�6F   $��Italic$�6^   $��18(�6q   $��31��6   $
��Left=�6�   $	��482��6�   $��Times New Roman)�6�   $
��Bold"�6�   5      � 5   
   $
��Left=�6   $	��179��6*   $��
-3,-3,0,-3q�66   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[    �� RelativeTransform 5      V� 5      .~�5      �� 	 �� CenterY$		 0.5Q�6-   
 �� CenterX$	
 0.5Q�6;   �� 5       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5       �� Angle$ 90.637Q�6.    �� CenterY$	 0.5Q�6=    �� CenterX$	 0.5Q�6K   T� 5      5      .��5      �  � Offset$ 1Q�6#    � Color$ 	#FF949494��6.   � 5       $ 	#FFBFBFBF��6#   5!      .+�5#      � $��0,172,0,118q�6   .+�5$      �� -   5        $��Tables��5$      $��Таблицы��6'   $��0,40,51.2,0q�69   $	��Top=�6N   $��Yu Gothic UI Light)�6�   $��22(�6�   $��Right=�6�   $��92��6�   ��6f   Z� ��6�   Z� 6�   �� 5%      -   5        $��Users��5%      $��Пользователи��6&   $��
0,79,0.2,0q�6=   $	��Top=�6Q   $��22(�6�   $��Yu Gothic UI Light)�6�   $��Right=�6�   $	��143��6�   ��6i   Z� ��6�   Z� 6�   �� 5&      -   5        $��Settings��5&      $��Настройки��6)   $��0,118,30.2,0q�6=   $	��Top=�6S   $��22(�6�   $��Yu Gothic UI Light)�6�   $��Right=�6�   $	��113��6�   $��35��6  ��6k   Z� ��6�   Z� 6  �� 5'      -   5        $
��Home��5'      $��
Домой��6%   $	��Top=�65   $��Yu Gothic UI Light)�6�   $��24(�6�   $��
0,0,64.2,0q�6�   $��Right=�6�   $��79��6�   ��6M   Z� ��6v   Z� 6�   �� 5(      $��Right=�6   $��24��64   $��0,84,148.2,0q�6@   $	��Top=�6V   $��24��6n   $��icons/users.png��6y   �� 5)      $��Right=�6   $��27��64   $��0,124,147.2,0q�6@   $	��Top=�6W   $��27��6o   $��icons/settings.png��6z   �� 5*      $��24��6   $��0,50,148.2,0q�6$   $	��Top=�6:   $��icons/table.png��6R   $��Right=�6k   $��24��6�   �� 5+      $��25��6   $��0,10,148.2,0q�6$   $	��Top=�6:   $��icons/home.png��6R   $��Right=�6j   $��24��6�   �� 5,      -	   5         ��Name$ 	Home_Copy��5,      $��
Войти��6,   $	��Top=�6<   $��Times New Roman)�6�   $��24(�6�   $��7,-40,4.2,0q�6�   $��Italic$�6�   ��6T   Z� ��6j   Z� 6�   �� 5-      -
   5        $ Report��5-      $��
Отчёт��6)   $��
0,158,73,0q�69   $	��Top=�6M   $��22(�6�   $��Yu Gothic UI Light)�6�   $��Right=�6�   $��70��6�   $��35��6�   ��6e   Z� ��6{   Z� 6�   �� 5.      $��Right=�6   $��32��64   $��0,161,144,0q�6@   $	��Top=�6U   $��32��6m   $��icons/doc.png��6x   5/      �� 50      -   5        $��Avatar��50      $	��100��6"   $��
38,10,40,0q�6/   $	��Top=�6C   $��icons/user.png��6[   6�   51      � 52   
   -   5        $��MainGrid��52      $��175,29,-3.8,-3q�6   ���	#FFBFBFBF.+�54      � -   5        $��gTables��54      $y�Hidden=�6"   $��10q�66    55      �� 56      .+�58      �� -   5        $��listViewTables��58      $��0,45,10.2,10q�61   $��16(�6G    � 	Resources 59       �� 
TargetType��%+   '��       �� 5:      " ��6    5<      5=       �� View 5>      �� 5?      .P�5@      �� $�� ��6-    �� Width$	 100��6b    �� DisplayMemberBinding 67   ��  �� Path$
 Col1�6b   �� 5A      $�� ��6-   $	 100��6b    67   �� $
 Col2�6b   �� 5B      $�� ��6-   $	 100��6b    67   �� $
 Col3�6b   �� 5C      $�� ��6-   $	 100��6b    67   �� $
 Col4�6b   �� 5D      $�� ��6-   $	 100��6b    67   �� $
 Col5�6b   5E      5G      �� 5H      -   5        $��comboBoxTable��5H      $
��Left=�60   $��	79,15,0,0q�6K   $	��Top=�6^   $	��201��6v   $��14(�6�   .@�5I      �� .��6#   Учебный план61   �� 5J      .��6#   Занятые темы61   �� 5K      .��6#   Группы6+   �� 5L      .��6#   Специальности62   �� 5M      .��6#   Студенты6-   �� 5N      .��6#   Предметы6-   �� 5O      .��6#   
Темы6)   5P      �� 5Q      $��Таблица��6   $
��Left=�6*   $��0,10,0,0q�6E   $	��Top=�6W   $��Times New Roman)�6o   $��18(�6�   �� 5R      -   5        $��	ButtonAdd��5R      {�.  $y�Visible=�6<   $��Добавить��6Q   $
��Left=�6d   $��
285,15,0,0q�6   $	��Top=�6�   $��84��6�   $��24��6�   $��16(�6�   6�   �� 5S      -   5        $��ButtonDelete��5S      {�.  $y�Visible=�6?   $��Удалить��6T   $
��Left=�6f   $��
374,15,0,0q�6�   $	��Top=�6�   $��84��6�   $��24��6�   $��16(�6�   6�   �� 5T      -   5        $ 
distribute��5T      {�.  $y�Hidden=�6?   $��Распределить��6S   $
��Left=�6j   $��
463,16,0,0q�6�   $	��Top=�6�   $��84��6�   $��24��6�   6�   5U      � 5W      -   5        $��gUsers��5W      $y�Hidden=�6!   $��10q�65   .+�5X      �� -   5        $��listViewUsers��5X      $��0,57,10,10.4q�60   $��16(�6F    5Y      �� 5Z      .P�5[      �� $��Login��6-   $	 100��6c    6<   �� *Login+6c   �� 5\      $
��Role��6-   $	 100��6a    6;   �� *Role+6a   �� 5]      $
��Name��6-   $	 100��6a    6;   �� *Name+6a   �� 5^      $��Surname��6-   $	 100��6g    6>   �� *	Surname+6g   �� 5_      $��Gender��6-   $	 100��6e    6=   �� *Gender+6e   5`      5b      �� 5c      $��Роль��6   $
��Left=�6'   $��	10,16,0,0q�6B   $	��Top=�6U   $��18(�6m   $��Times New Roman)�6{   �� 5d      -   5        $��comboBoxRole��5d      $
��Left=�6/   $��
137,16,0,0q�6J   $	��Top=�6^   $	��221��6v   $��30��6�   $��16(�6�   .@�5e      �� $��Все��6#   �� 5f      $��Admin��6#   �� 5g      $��Depot��6#   �� 5h      $��Teacher��6#   �� 5i      $��Student��6#   5j      �� 5k      -   5        $ 
ButtonAdd2��5k      $��Добавить��6-   $
��Left=�6@   $��
378,16,0,0q�6[   $	��Top=�6o   $��96��6�   $��30��6�   $��18(�6�   �� 5l      -   5        $ ButtonDelete2��5l      $��Удалить��60   $��479,16,10.2,0q�6B   $	��Top=�6Y   $��30��6q   $��18(�6�   5m      � 5o      -   5        $��	gSettings��5o      $y�Visible=�6$   $	��418��69   $��
10,10,10,0q�6F   $	��Top=�6Z   .+�5p      � $��
10,27,10,0q�6   ���	#FFAEAEAE$��79��6B   $	��Top=�6N   .+�5q      �� -   5        $��connectionString��5q      {�.  $��0,0,0,2q�6H    �� TextWrapping$
 Wrap=�6Y   $c��]server=localhost;persistsecurityinfo=True;database=mydb;allowuservariables=True;SslMode=none;��6m   $��16(�6�   ��6�   Z� 6�   5r      �� 5s      $)��#Строка подключения��6   $	��Top=�65   $��217,0,216,0q�6M   $��27��6b   $��Times New Roman)�6n   $��16(�6�   �� 5t      $%��Другие параметры��6   $	��Top=�63   $��223,106,224,0q�6K   $��27��6b   $��Times New Roman)�6n   $��16(�6�   � 5u      $��
11,138,8,0q�6   ���	#FFAEAEAE$	��124��6B   $	��Top=�6O   .+�5v      �� $��
0,0,-0.2,0q�6   $
 Wrap=�62   $��16(�6\   ��6F   Z� 6\   �� 5w      -   5        $��Лог файл��5w      $
��Left=�60   $��	10,10,0,0q�6K   $	��Top=�6^   $��75��6v   6�   5x      5z      � 5|      -   5        $��gHome��5|      $y�Hidden=�6    $��10q�64   .+�5}      � $��0,80,20.2,0q�6   ���	#FFCDCDCD$��55��6C   $	��Top=�6O    J� Effect 5~      -  'System.Windows.Media.Effects.BlurEffect  5      5�      �� 5�      $��10,80,17.2,0q�6   $
��Wrap=�62   $��16(�6F   $��55��6T   $	��Top=�6`   �� 6y   $-�'Студент: Максимов И.А.��6}   �� 6�   �� 6�   $;�5Преподаватель: Ларионова Е.А.��6�   6�   � 5�      $��
2,149,18,0q�6   ���	#FFCDCDCD J� Opacity$
 0.74Q�6B   $��55��6Q   $	��Top=�6]    5�        5�      5�      �� 5�      $��10,149,18,0q�6   $
��Wrap=�61   $��16(�6E   $��55��6S   $	��Top=�6_   �� 6x   $s�mТема курсовой: Просмотр и изменение занятых тем у студентов��6|   �� 6�   �� 6�   $�Сервер ��6�   �� 6�   $�MySQL��6�   �� 6�   $� ��6�   �� 6  $�& ��6  �� 6  $�Приложение ��6  �� 61  $�WPF .Net��65  6H  �� 5�      $��207,-1,231,0q�6   $��icons/UNIKIT.png��6.   $��76��6H   $	��Top=�6T   5�      � 5�      -   5        $��gUser��5�      $y�Hidden=�6    $��10q�64   .+�5�      �� -   5         ��Name$ Avatar_Copy��5�      $	��199��6-   $��194,10,194,0q�6:   $	��Top=�6P   $��icons/user.png��6h   � 5�      $��170,250,166.2,105q�6   .+�5�      �� -   5         ��Name$ Surname_Copy��5�      $��Center=�62   $��Фамилия��6V   $��	0,33,0,40q�6h   $��Italic$�6{   $��18(�6�   �� 5�      -   5        $ 	Name_Copy��5�      $��Center=�6/   $��Имя��6S   $��	0,-6,2,80q�6a   $��Italic$�6t   $��18(�6�   �� 5�      -    5        $ Surname_Copy1��5�      $��Center=�63   $��
Права��6W   $��0,73,1,0q�6g   $��18(�6y   5�      5�      5�      5�      5�      