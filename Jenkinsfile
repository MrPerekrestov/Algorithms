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
        dir(path: 'd:\\jenkins') {
          bat 'dotnet test d:\\jenkins\\Algorithms.sln --logger "junit;LogFilePath=d:\\jenkins\\test_results\\test_results.xml"'
          junit 'test_results/*'
        }

      }
    }

  }
}