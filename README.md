<h1><a id="Payment_Gateway_APIs_0"></a>Payment Gateway APIs</h1>
<p>This is a set of APIs that connects merchants to acquiring banks to allow them to send their payments. They call also call an API to get the status of their payments.</p>
<h1><a id="Features_6"></a>Features!</h1>
<ul>
<li>Uses EntityFramework Core (InMemory Provider) for data storage</li>
<li>Uses CompositionRoot pattern to register all dependencies using Native .NET Core Dependency Injection</li>
<li>Interface-based programming</li>
<li>Validation with FluentValidation</li>
<li>Unit tests using <a href="http://xUnit.net">xUnit.net</a></li>
<li>Swashbuckle to generate API documentation + UI to explore and test endpoints</li>
<li>AutoRest to generate a client API</li>
</ul>
<h3><a id="Installation_16"></a>Installation</h3>
<p>Core Requirements</p>
<ul>
<li>.NET Core 1.1+</li>
</ul>
<p>Optional Requirements</p>
<ul>
<li>Docker</li>
</ul>
<h3><a id="Usage_24"></a>Usage</h3>
<pre><code class="language-sh"><span class="hljs-comment"># build and start the API service</span>
Run .\Build.ps1 <span class="hljs-keyword">in</span> PowerShell
<span class="hljs-comment"># access</span>
http://localhost:<span class="hljs-number">58427</span>/{endpoints} see below <span class="hljs-keyword">for</span> the endpoints
</code></pre>
<h3><a id="Endpoints_33"></a>Endpoints</h3>
<p>Create Payment:</p>
<pre><code class="language-sh">POST /api/v1/payments
</code></pre>
<p>Request body</p>
<pre><code class="language-sh">{
  <span class="hljs-string">"amount"</span>: <span class="hljs-number">450</span>,
  <span class="hljs-string">"currency"</span>: <span class="hljs-string">"GBP"</span>,
  <span class="hljs-string">"merchantid"</span>:<span class="hljs-string">"testmerchant"</span>,
  <span class="hljs-string">"customer"</span>: {
    <span class="hljs-string">"Email"</span>: <span class="hljs-string">"merchant@gmail.com"</span>,
    <span class="hljs-string">"firstname"</span>: <span class="hljs-string">"test"</span>,
    <span class="hljs-string">"lastname"</span>: <span class="hljs-string">"test"</span>
  },
  <span class="hljs-string">"card"</span>: {
    <span class="hljs-string">"number"</span>: <span class="hljs-string">"1234555599996666"</span>,
    <span class="hljs-string">"expirymonth"</span>: <span class="hljs-number">10</span>,
    <span class="hljs-string">"expiryyear"</span>: <span class="hljs-number">2019</span>,
    <span class="hljs-string">"cvv"</span>: <span class="hljs-string">"1235"</span>
  }
}
</code></pre>
<p>Important Note: The credit card number is encypted before being saved in the payment gateway’s database.</p>
<p>Sample response</p>
<pre><code class="language-sh">{
    <span class="hljs-string">"code"</span>: <span class="hljs-number">8000</span>,
    <span class="hljs-string">"message"</span>: <span class="hljs-string">"SUCCESS"</span>,
    <span class="hljs-string">"paymentId"</span>: <span class="hljs-string">"592d41b8-0e0b-4911-8320-cf2ee38de506"</span>
}
</code></pre>
<p>Check Payment Status:</p>
<pre><code class="language-sh">GET /api/v1/paymentstatus/{paymentId}
</code></pre>
<p>Sample response</p>
<pre><code class="language-sh">{
    <span class="hljs-string">"id"</span>: <span class="hljs-string">"MCB-098678-c8362b39-3d90-4e73-bc91-c017c81c15d6"</span>,
    <span class="hljs-string">"paymentRequestId"</span>: <span class="hljs-string">"fa6d3991-874a-4b76-b054-da498fd090a8"</span>,
    <span class="hljs-string">"amount"</span>: <span class="hljs-number">450</span>,
    <span class="hljs-string">"currency"</span>: <span class="hljs-string">"GBP"</span>,
    <span class="hljs-string">"statusCode"</span>: <span class="hljs-number">8000</span>,
    <span class="hljs-string">"status"</span>: <span class="hljs-string">"SUCCESS"</span>,
    <span class="hljs-string">"card"</span>: {
        <span class="hljs-string">"number"</span>: <span class="hljs-string">"1234 **** **** 6666"</span>,
        <span class="hljs-string">"expiryMonth"</span>: <span class="hljs-number">10</span>,
        <span class="hljs-string">"expiryYear"</span>: <span class="hljs-number">2019</span>,
        <span class="hljs-string">"cvv"</span>: <span class="hljs-string">"****"</span>
    }
}
</code></pre>
<h3><a id="Assumptions_92"></a>Assumptions</h3>
<ul>
<li>The Merchant is already registered with Payment gateway.</li>
<li>There is only one acquiring bank.</li>
<li>Both the acquiring bank and payment gateway use the same encryption key to encrypt and decrypt credit card numbers.</li>
<li>The request to be sent to the acquiring bank and the response to be received from the bank are flat. There is no hierarchy. Hence, the there is no object hierarchy in the Dtos.</li>
<li>The bearer token NWY5MzAxNTU4OWZjZWEwMThmMGMyZDk3YmQwYTM1MDgxODZhOGI3ZDM2MDU5MWIwNTQ3ZDA3NDNk is used for authentication. It has to be added in the Authorization header in the client (example: Postman).</li>
</ul>
<h3><a id="Improvements_99"></a>Improvements</h3> <ul> <li>Use a containerized DB instead of InMemory.</li> <li>The initialization vector in the encryption algorithm should be randomized.</li> <li>Log4Net could be integrated in the application instead of the native .net core logging.</li> <li>An identity server could be set up to generate and verify the bearer tokens</li></ul>
