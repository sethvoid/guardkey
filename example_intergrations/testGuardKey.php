<?php

include('guardkey.php');
$guardKey = new guardKey();
$username = null;
$password = null;
$testKey  = null;
$privateKey = file_get_contents('guardkey.pem');
foreach ($argv as $argument) {
    if (strpos($argument, '--username') !== false) {
        $tmp = explode('=', $argument);
        $username = $tmp[1];
    }

    if (strpos($argument, '--password') !== false) {
        $tmp = explode('=', $argument);
        $password = $tmp[1];
    }

    if (strpos($argument, '--test') !== false) {
        $tmp = explode('=', $argument);
        $testKey = $tmp[1];
    }
}

if (empty($username) || empty($password)) {
    exit('Missing arguments.--username, --password' . PHP_EOL);
}

$guardkeytest = $guardKey->setUsername($username)
    ->setPassword($password)
    ->setPrivateKey($privateKey)
    ->generateGuardKey()
    ->verifyGuardKey($testKey);

echo 'TESTING ' . $testKey . PHP_EOL;
echo '        ' . $guardKey->getSelfGeneratedGuardKey() . PHP_EOL;
echo 'Result ' . ($guardkeytest ? 'true' : 'false') . PHP_EOL;
echo 'Test Ends.' . PHP_EOL;

