<?php


class guardKey {
    /**
     * @var string
     */
    private $privateKey;

    /**
     * @var string
     */
    private $username;

    /**
     * @var string
     */
    private $hashedPassword;


    private $selfGeneratedGuardKey;
    /**
     * @return mixed
     */
    public function getPrivateKey()
    {
        return $this->privateKey;
    }

    /**
     * @param mixed $privateKey
     */
    public function setPrivateKey(string $privateKey): guardKey
    {
        $this->privateKey = $privateKey;

        return $this;
    }

    /**
     * @return mixed
     */
    public function getUsername()
    {
        return $this->username;
    }

    /**
     * @param mixed $username
     */
    public function setUsername(string $username): guardKey
    {
        $this->username = $username;

        return $this;
    }

    /**
     * @return mixed
     */
    public function getHashedPassword()
    {
        return $this->hashedPassword;
    }

    /**
     * @param mixed $hashedPassword
     */
    public function setHashedPassword(string $hashedPassword): guardKey
    {
        $this->hashedPassword = strtoupper($hashedPassword);

        return $this;
    }

    /**
     * @param string $plainText
     *
     * @return guardKey
     *
     */
    public function setPassword(string $plainText) : guardKey
    {
        $this->hashedPassword = strtoupper(hash('SHA512', $plainText));

        return $this;
    }

    /**
     *
     * @return mixed
     *
     */
    public function getSelfGeneratedGuardKey() {
        return $this->selfGeneratedGuardKey;
    }

    /**
     *
     * @return guardKey
     *
     */
    public function generateGuardKey(): guardKey {
        $username = strtoupper(hash('SHA512', $this->username));

        $dateTime = strtoupper(hash('SHA512', intval(date('H')) . date('dnY')));

        $privateKey = strtoupper(hash('SHA512', $this->privateKey));

        $hashedCalculation = strtoupper(hash('SHA512', $username . $this->hashedPassword . $dateTime . $privateKey));

        $this->selfGeneratedGuardKey = $hashedCalculation;

        return $this;
    }

    /**
     * @param string $suppliedGuardKey
     *
     * @return bool
     *
     */
    public function verifyGuardKey(string $suppliedGuardKey) : bool
    {
        return $this->selfGeneratedGuardKey == $suppliedGuardKey ? true : false;
    }
}