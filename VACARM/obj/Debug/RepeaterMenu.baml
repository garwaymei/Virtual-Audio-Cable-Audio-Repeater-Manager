   M S B A M L   `   `   `  ����A  =VACARM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VACARMVACARM  5   	       VACARM.RepeaterMenu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:VACARM     5   	     � Title$  RepeaterMenu��5   	   $��393.5��6   $	��300��6-   ���#222222
�������.��5
      �� $��10q�6   .+�5   
   �� $��Sample rate��6   �� 5   
   -   5         ��Name$ samplingRate��5      ��6(   ��  �� Path$ SamplingRate� �� Mode$ TwoWay=��� 5   
   $��Bits per sample��6   �� 5   
   -   5        $ bitsPerSample��5      ��6)   �� $ BitsPerSample�$ TwoWay=��� 5   
   $��Channel config��6   �� 5   
   -   5         ��Name$ channelConfig��5       �� SelectedItem 6*   �� $ ChannelConfig�$ TwoWay=���6c   �� $ ChannelConfigs�$ OneTime=�� 5   
   -   5         �Name$ channels��5       � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5       $��* �6#   �� 5!      $��* �6#   5#      �� 5$   
   $��Total buffer (ms)��6   �� 5%   
   -   5        $ bufferMs��5%      ��6$   �� $ BufferMs�$ TwoWay=��� 5&   
   $��Buffers��6   �� 5'   
   -   5        $ buffers��5'      ��6#   �� $ Buffers�$ TwoWay=��� 5(   
   $��Pre-fill to, %��6   �� 5)   
   -   5        $ prefill��5)      ��6#   �� $ Prefill�$ TwoWay=��� 5*   
   $��Resync at, %��6   �� 5+   
   -   5        $ resyncAt��5+      ��6$   �� $ ResyncAt�$ TwoWay=��� 5,   
   -	   5        	 ��Name$	 deleteButton��5,      $��Delete Link��6'   6=   � 5-   
   $��
150 10 0 0q�6   .+�5.      �� -
   5        $
��Okay��5.      6$   5/      50      51      