pipeline {
  agent any
  stages {
    stage('print message') {
      steps {
        echo 'test'
        sh 'cd d:\\jenkins'
      }
    }

    stage('git clone') {
      steps {
        git 'https://github.com/MrPerekrestov/Algorithms.git'
      }
    }

  }
}