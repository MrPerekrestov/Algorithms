pipeline {
  agent {
    node {
      label 'windows'
    }

  }
  stages {
    stage('build') {
      steps {
        dir(path: 'd:\\jenkins') {
          bat 'dotnet restore'
          bat 'dotnet build'
        }

      }
    }

    stage('tests') {
      steps {
        nunit()
      }
    }

  }
}