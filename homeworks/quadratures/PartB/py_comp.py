import numpy as np
from scipy import integrate

def f1(x):
    return 1/np.sqrt(x)

def f2(x):
    return np.log(x)/np.sqrt(x)

Q1, err1, args1 = integrate.quad(f1,0,1,epsabs=0.001, epsrel=0.001, full_output=True)
Q2, err2, args2 = integrate.quad(f2,0,1,epsabs=0.001, epsrel=0.001, full_output=True)

print("--------EVALUATING PYTHON'S QUAD IMPLEMENTATION--------")
print("1/Sqrt(x): " +str(Q1) +". Number of steps: " +str(args1['neval'])+".")
print("Log(x)/Sqrt(x): " +str(Q2) +". Number of steps: " +str(args2['neval'])+".")