   M S B A M L   `   `   `  ����B  >Journal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Journal.ViewsJournal.Views  5      #    Journal.Views.TeacherPageView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Journal.Views     5        N� Title$  TeacherPageView��5	       N� 
Background �	#FF2E3440.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $��0,0,0,10q�6;   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Segoe UI)�6e   $��SemiBold"�6{   $��14(�6�   $	��300��6�   ��6   �� *
Teachers+ �� SelectedItem 6<   �� *SelectedTeacher+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6+      ShadowDepth$ 2Q�6;      Opacity$	 0.5Q�6K   	 �� View	 5      �� 5      .P�5      �� $��ID��6-   
 �� DisplayMemberBinding
 69   �� *Id+�� 5      $��Имя��6-   
 6:   �� *	FirstName+�� 5      $��Фамилия��6-   
 6>   �� *
LastName+�� 5      $��Предметы��6-    �� CellTemplate 5   "   �� 5   &   .R�5    *   �� ��64   �� *
Subjects+   SubjectsConverter �� 	Converter# [  5!   '   5#      �� 5$       5%   "   �� 5&   &   .R�5'   *   �� $	��❌��61   $��5q�6�   ���#D08770
�������$��0q�6  $��30��6  $��30��6%  #��[" �61  ��6=   �� *" DataContext.DeleteTeacherCommand+ �� RelativeSource ��  �� AncestorType" ����6�   �� *Id+61  5(   '   5*      5+      5-      5.      �� 5/      $��10,0,0,0q�6   $	��300��6+   .+�50      �� $��Segoe UI)�6   $��12(�6.   $��SemiBold"�6<   $��Имя учителя��6R   $��0,0,0,0q�6h   $��0,0,0,2q�6z   �� 51      $��Segoe UI)�6h   $��SemiBold"�6~   $��14(�6�   $��0,0,0,5q�6�   ���#ECEFF4���#D8DEE9$��1q�6�   ��6   �� *CreateTeacher.FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 52      $��Segoe UI)�6   $��12(�6.   $��SemiBold"�6<   $#��Фамилия учителя��6R   $��0,0,0,0q�6l   $��0,0,0,2q�6~   �� 53      $��Segoe UI)�6g   $��SemiBold"�6}   $��14(�6�   $��0,0,0,5q�6�   ���#ECEFF4���#D8DEE9$��1q�6�   ��6   �� *CreateTeacher.LastName+$ PropertyChanged=�6�   �� 54      $%��Добавить препода��6   $��Segoe UI)�6Z   $��14(�6p   $��SemiBold"�6~   $
��10,5q�6�   ���#A3BE8C
�������$��0q�6�   $��40��6�   #��[" �6�   $��0,0,0,20q�6&  ��64   �� *AddTeacherCommand+6&  �� 55      $��Segoe UI)�6   $��12(�6.   $��SemiBold"�6<   $��Предмет��6R   $��0,0,0,0q�6d   $��0,0,0,2q�6v   �� 56       �� DisplayMemberPath$
 Name��6<   $��Segoe UI)�6~   $��SemiBold"�6�   $��14(�6�   $��0,0,0,5q�6�   ���#ECEFF4���#D8DEE9$��1q�6�   ��6   �� *
Subjects+ 6U   �� *SelectedSubject+6�   �� 57      $%��Добавить предмет��6   $��Segoe UI)�6Z   $��14(�6p   $��SemiBold"�6~   $
��10,5q�6�   ���#A3BE8C
�������$��0q�6�   $��40��6�   #��[" �6�   $��0,0,0,20q�6&  ��64   �� *AddSubjectCommand+6&  58      59      5:      5;      