   M S B A M L   `   `   `  ����B  >Journal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Journal.ViewsJournal.Views  5      #    Journal.Views.SubjectPageView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Journal.Views     5        N� Title$  SubjectPageView��5	       N� 
Background �	#FF2E3440.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��1��6   $��0,0,0,10q�6"    �� Orientation$ 
Horizontal=�64   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Segoe UI)�6<   $��SemiBold"�6R   $��14(�6h   $
}�True��6v   $	��300��6�   ��6   �� *
Subjects+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6+      ShadowDepth$ 2Q�6;      Opacity$	 0.5Q�6K    �� View 5      �� 5      .P�5      �� $��ID��6-   	 �� DisplayMemberBinding	 69   �� *Id+�� 5      $��Название��6-   	 6?   �� *Name+�� 5      
 �� CellTemplate
 5   "   �� 5   &   .R�5   *   �� $	��❌��61   $��5q�6�   ���#D08770
�������$��0q�6  $��30��6  $��30��6%  #��[" �61  ��6=   �� *" DataContext.DeleteSubjectCommand+ �� RelativeSource ��  �� AncestorType" ����6�   �� *Id+61  5   '   5!      5"      5$      5%      �� 5&      $��10,0,0,0q�6   $	��300��6+   .+�5'      �� $��Segoe UI)�6   $��12(�6.   $��SemiBold"�6<   $'��!Название предмета��6R   $��0,0,0,0q�6n   $��0,0,0,2q�6�   �� 5(      $��Segoe UI)�6c   $��SemiBold"�6y   $��14(�6�   $��0,0,0,5q�6�   ���#ECEFF4���#D8DEE9$��1q�6�   ��6   �� *CreateSubject.Name+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5)      $%��Добавить предмет��6   $��Segoe UI)�6Z   $��14(�6p   $��SemiBold"�6~   $
��10,5q�6�   ���#A3BE8C
�������$��0q�6�   $��40��6�   #��[" �6�   ��64   �� *AddSubjectCommand+6�   5*      5+      5,      5-      