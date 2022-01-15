# Partial failures and Exponential Backohh tecnique

In a distributed system, whenever a service makes a synchronous request to anotther service, there is a ever-present risk of partial falire.

* You must design your service to be resilient to those partial failures

<img src="../docs/images/partial-failures.PNG" alt="Partial Failures" />

## Settings Timeouts

A service client shlod be designed nto to block indefinitely and use timeouts.

<img src="../docs/images/setting-timeouts.PNG" alt="Setting Timeouts" />


## Retries wih Exponential Backoff

Perform call retries a certian number of times with a longer wait between each retry.

<img src="../docs/images/retries-with-exponential-backoff.PNG" alt="Retries with Exponential Backoff" />

```dotnet add package Microsoft.Extensions.Http.Polly```