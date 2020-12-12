#!/bin/bash

# Source the setup file from the simulator workspace
source ~/sim_ws/devel/setup.bash

# Store arguments into variables
RECPATH=$1
echo frames are grabbed from folder $RECPATH
TRESHOLD=$2
echo contrast treshold is $TRESHOLD

# Start roscore
roscore &
sleep 2

# Move to esim_ros folder and do conversion
roscd esim_ros
python scripts/generate_stamps_file.py -i $RECPATH -r 60.0
rosrun esim_ros esim_node \
 --data_source=2 \
 --path_to_output_bag=/tmp/out.bag \
 --path_to_data_folder=$RECPATH \
 --ros_publisher_frame_rate=60 \
 --exposure_time_ms=10.0 \
 --use_log_image=1 \
 --log_eps=0.1 \
 --contrast_threshold_pos=$TRESHOLD \
 --contrast_threshold_neg=$TRESHOLD

# Remove frames since no more needed
rm -r $RECPATH

# Renderer
rosrun dvs_renderer dvs_renderer events:=/cam0/events &>/dev/null &
sleep 1

# Display on screen the resulting simulated footage
rosbag play /tmp/out.bag -l -r 1 &>/dev/null & 
sleep 1
rqt_image_view /dvs_rendering

# Kill processes
# How to kill processes after user closes window?
# pgrep roscore
# sleep 5
# pkill roscore

