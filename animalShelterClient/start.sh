#!/bin/bash
$(/usr/sbin/sshd -D) &
$(http-server dist) &
tail -f /dev/null