The typical adaptive quadrature uses a subdivision into two smaller intervals whenever the error is above 
the accepted tolerance. In this project, instead of a subdivision into two smaller intervals, we subdivide
into three smaller intervals.

The algorith uses a 3-point open quadrature with reusable points, which makes for easy calculation of 
the relevant points and weights. At each point, the value of the given function is evalueted, and using 
these evaluations, a lower and a higher order rule is calculated. The absolute difference between these
two rules determines the error, and if the error is within tolerance, the step is accepted. If the error
is not within tolerance, the interval is subdivided into three subintervals, and the algorithm is repeated 
for each subinterval. When all subroutines (and if necessary, subroutines of subroutines) have errors within
tolerance, the numerical integral over the whole interval is computed. 

This routine proves to be, atleast for the functions tested in this script, more efficient than the 
standard subdivision in two intervals, requiring far fewer iterations to reach a result.

Personal evaluation: I have done what the exam project demands, but not more than that. As such, i judge this
project to be worth 6 points.