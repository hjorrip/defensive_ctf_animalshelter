#!/bin/bash
$(/usr/sbin/sshd -D) &
$(dotnet run) &
tail -f /dev/null