   M S B A M L   `   `   `  ����B  >Journal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Journal.ViewModelsJournal.ViewModels  5   	   -clr-namespace:Journal.ViewsJournal.Views  5   	       Journal.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2local clr-namespace:Journal.ViewModels     5   	   -viewsclr-namespace:Journal.Views     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$!  Программа-ВВГУ��5	   	   $��Comic Sans MS)�6    $��14(�6;   $
��Bold"�6I   ���	#FF2E3440 � SizeToContent$ WidthAndHeight=�5
   	   $	��500��5   	   $	��400��5   	    � DataContext 5      &    Journal.ViewModels.MainViewModel  5   
   .��5      � .+�5   
   ]� .+�5      �� $
��Left=�6   $	��Top=�64   $��20,20,10,20q�6L   ���#4C566A$	��220��6v   .+�5      �� $��Группы��6   $
��10,5q�6*   $��20(�69   $��Comic Sans MS)�6G   $
��Bold"�6b   $��	0,10,0,10q�6�   ���#5A5D6F
�������$��0q�6�   $��40��6�   ��6t   �� *ShowGroupPageCommand+6�   �� 5      $��Студенты��6   $
��10,5q�6,   $��20(�6;   $��Comic Sans MS)�6I   $
��Bold"�6d   $��	0,10,0,10q�6�   ���#5A5D6F
�������$��0q�6�   $��40��6�   ��6v   �� *ShowStudentPageCommand+6�   �� 5      $��Предметы��6   $
��10,5q�6,   $��20(�6;   $��Comic Sans MS)�6I   $
��Bold"�6d   $��	0,10,0,10q�6�   ���#5A5D6F
�������$��0q�6�   $��40��6�   ��6v   �� *ShowSubjectPageCommand+6�   �� 5      $��Учителя��6   $
��10,5q�6+   $��20(�6:   $��Comic Sans MS)�6H   $
��Bold"�6c   $��	0,10,0,10q�6�   ���#5A5D6F
�������$��0q�6�   $��40��6�   ��6u   �� *ShowTeacherPageCommand+6�   �� 5      $��Расписание��6   $
��10,5q�6.   $��20(�6=   $��Comic Sans MS)�6K   $
��Bold"�6f   $��	0,10,0,10q�6�   ���#5A5D6F
�������$��0q�6�   $��40��6�   ��6x   �� *ShowSchedulePageCommand+6�   �� 5      $��
Выход��6   $
��10,5q�6)   $��20(�68   $��Comic Sans MS)�6F   $
��Bold"�6a   $��0,50,0,0q�6�   ���#BF616A
�������$��0q�6�   $��40��6�   ��6s   �� *RunExitProgram+6�   5       � 5        � NavigationUIVisibility$ Hidden=�6   $��20q�6T   ��64   �� *CurrentView+6T   5      5      5      