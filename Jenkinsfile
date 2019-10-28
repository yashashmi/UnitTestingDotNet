node {
    def imageName = 'mcr.microsoft.com/dotnet/core/sdk:2.2'
    def volumeMountingArg = "--volume ${WORKSPACE}:/usr/src"
    def msImage = docker.image("${imageName}")

    stage("CheckOut"){
        git credentialsId: 'GitCredentials', url: 'https://github.com/yashashmi/UnitTestingDotNet'
    }
	msImage.inside("${volumeMountingArg}"){
        stage("Restore"){
            sh "dotnet restore"
        }

        stage("Build"){
           sh "dotnet build -c Release"
        }

        stage("Test"){
            sh "dotnet test --verbosity=minimal --logger 'trx;LogFileName=testresults.trx'"
        }
        
        stage("Publish Test Result"){
            mstest keepLongStdio: true, testResultsFile: '**/testresults.trx'
        }
    }
}