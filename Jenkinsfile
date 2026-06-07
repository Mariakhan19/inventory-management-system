pipeline {
    agent any

    stages {

        stage('GitHub Clone') {
            steps {
                git branch: 'main',
                    url: 'https://github.com/Mariakhan19/inventory-management-system.git'
            }
        }

        stage('Build Backend Image') {
            steps {
                sh 'docker build -t inventory-backend ./backend'
            }
        }

        stage('Build Frontend Image') {
            steps {
                sh 'docker build -t inventory-frontend ./frontend'
            }
        }

        stage('Deploy') {
            steps {
                sh '''
                docker stack deploy -c docker-compose.yml inventory-app
                '''
            }
        }
    }
}
