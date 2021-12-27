# Logitech Game Monitor

## Problem
Logitech Gaming software can trigger profiles based on a running application/game. However, It needs the full path to the executable.

If you install games via the Xbox App then you can't get the Logitech software to trigger.

## Solution
This application will monitor for a service _by name_ and then spin up a mini process. The mini process will be created with an actual path that the Logitech Gaming Software can watch for.

---
### Additional Goals
* Begin Working with Concourse
* Install Concourse at home