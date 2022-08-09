pipeline {
  agent {
    node {
      label 'windows'
    }

  }
  stages {
    stage('git clone') {
      steps {
        echo 'Starting build'
        dir(path: 'd:\\jenkins') {
          git 'https://github.com/MrPerekrestov/Algorithms.git'
        }

      }
    }

  }
}