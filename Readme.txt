* Project-Start 2011-11
* (c)Pixel Tomsen (chk) pixel.tomsen[at]gridnet.info
* https://github.com/PixelTomsen/OpenSimWatch 
*
* THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

This program monitors opensim region server and restarts (windows-host's).

current methods:
- Test of the process to be present
- Test using http-check, if this fails, the process terminates

Note:
- In regions with lots of prims and scripts http the interval is not set too low, because it takes some time until the region
  is online!
 
  
***************************************************************************************************************************** 
German:
  
dieses programm überwacht opensim region-server und startet sie neu (windows-host's).

derzeitige methoden : 
- test auf vorhanden sein des prozesses
- test mittels http-check, wenn dieser fehlschlägt, wird der prozess beendet

Hinweis:
- bei regionen mit vielen prims und scripts das http-intervall nicht zu niedrig setzen, denn es dauert einige zeit, bis die region
 online ist!