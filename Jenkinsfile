pipeline {
  agent {
    node {
      label 'windows'
    }

  }
  stages {
    stage('print message') {
      steps {
        echo 'Starting build'
        dir(path: 'd:\\jenkins')
      }
    }

    stage('git clone') {
      steps {
        git 'https://github.com/MrPerekrestov/Algorithms.git'
      }
    }

  }
}