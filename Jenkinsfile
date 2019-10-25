node {
    def imageName = 'mcr.microsoft.com/dotnet/core/sdk:2.2'
    def volumeMountingArg = '--volume /var/jenkins_home/workspace/UnitTestingDotNet-Pipeline:/usr/src'

    stage("CheckOut"){
        git credentialsId: 'GitCredentials', url: 'https://github.com/yashashmi/UnitTestingDotNet'
    }
    stage("Restore"){
		docker.image("${imageName}").inside("${volumeMountingArg}"){
            sh "dotnet restore"
        }
    }
    stage("Clean"){
		docker.image("${imageName}").inside("${volumeMountingArg}"){
            sh "dotnet clean"
        }
    }
    stage("Build"){
		docker.image("${imageName}").inside("${volumeMountingArg}"){
            sh "dotnet build -c Release"
        }
    }
}