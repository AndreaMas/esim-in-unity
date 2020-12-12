# esim-in-unity


The proposed scripts, to be included inside the Unity project, are two:
\begin{enumerate}
  \item a C\# script, that needs to be attached to a game object (can be any). This script is responsible for:
  \begin{itemize}
   \item showing a basic UI button in the Game View, used to start and stop the recording,
   \item displaying (in the game object's inspector) only the most significant event camera parameters to set,
   \item calling the following bash script as soon as the recording is stopped, sending as arguments the parameters specified by the User;
  \end{itemize}
  \item a bash script, that will automatically execute all the commands needed to run ESIM (remember to mark as executable).
\end{enumerate}

