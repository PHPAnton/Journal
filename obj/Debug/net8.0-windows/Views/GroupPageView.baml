   M S B A M L   `   `   `  ����B  >Journal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Journal.ViewModelsJournal.ViewModels  5      M+clr-namespace:Journal.ViewModels.ConvertersJournal.ViewModels.Converters  5      !    Journal.Views.GroupPageView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2local clr-namespace:Journal.ViewModels     5      B
converters+clr-namespace:Journal.ViewModels.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  GroupPageView��5	       N� 
Background �	#FF2E3440 � 	Resources 5      5   /Journal.ViewModels.Converters.SubjectsConverter   SubjectsConverter5   /Journal.ViewModels.Converters.StudentsConverter  StudentsConverter��%:   &	        &	        5   
   6'     5   
   6'   5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Segoe UI)�6a   $��SemiBold"�6w   $��14(�6�   $	��300��6�   ��6   �� *Groups+ �� SelectedItem 6:   �� *SelectedGroup+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6+      ShadowDepth$ 2Q�6;   	   Opacity$		 0.5Q�6K   
 �� View
 5      �� 5       .P�5!      �� $��ID��6-    �� DisplayMemberBinding 69   �� *Id+�� 5"      $��Название��6-    6?   �� *Name+�� 5#      $��Предметы��6-    �� CellTemplate 5$   "   �� 5%   &   .R�5&   *   �� ��64   �� *
Subjects+ �� 	Converter# [  5'   '   5)      �� 5*      $��Студенты��6-    5+   "   �� 5,   &   .R�5-   *   �� ��64   �� *
Students+# [ 5.   '   50      �� 51       52   "   �� 53   &   .R�54   *   �� $	��❌��61   $��5q�6�   ���#D08770
�������$��0q�6  $��30��6  $��30��6#  #��[" �6/  ��6=   �� * DataContext.DeleteGroupCommand+ �� RelativeSource ��  �� AncestorType" ����6�   �� *Id+6/  55   '   57      58      5:      5;      �� 5<      $��10,0,0,0q�6   $	��300��6+   .+�5=      �� $��Segoe UI)�6   $��12(�6.   $��SemiBold"�6<   $#��Название группы��6R   $��0,0,0,0q�6l   $��0,0,0,2q�6~   �� 5>      $��Segoe UI)�6a   $��14(�6w   $��0,0,0,5q�6�   ���#ECEFF4���#D8DEE9$��1q�6�   ��6   �� *CreateGroup.Name+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5?      $#��Добавить группу��6   $��Segoe UI)�6W   $��14(�6m   $��SemiBold"�6{   $
��10,5q�6�   ���#A3BE8C
�������$��0q�6�   $��0,0,0,20q�6�   $��40��6�   #��[" �6�   ��63   �� *AddGroupCommand+6�   �� 5@      $��Segoe UI)�6   $��12(�6.   $��SemiBold"�6<   $��Предмет��6R   $��0,0,0,0q�6d   $��0,0,0,2q�6v   �� 5A       �� DisplayMemberPath$
 Name��6<   $��Segoe UI)�6~   $��14(�6�   $��0,0,0,5q�6�   ���#ECEFF4���#D8DEE9$��1q�6�   ��6   �� *
Subjects+ 6U   �� *SelectedSubject+6�   �� 5B      $%��Добавить предмет��6   $
��10,5q�6Z   $��Segoe UI)�6i   $��14(�6   $��SemiBold"�6�   ���#A3BE8C
�������$��0q�6�   $��0,0,0,20q�6�   $��40��6�   #��[" �6�   ��64   �� *AddSubjectCommand+6�   5C      5D      5E      5F      