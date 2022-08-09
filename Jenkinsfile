pipeline {
  agent any
  stages {
    stage('print message') {
      steps {
        echo 'test'
        bat 'cd d:\\jenkins'
      }
    }

    stage('git clone') {
      steps {
        git 'https://github.com/MrPerekrestov/Algorithms.git'
      }
    }

  }
}