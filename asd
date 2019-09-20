import cv2

img = cv2.imread(r"D:\jupyter programe\opencv\six\img7.jpg",0)
cv2.imshow("src",img)
thresh, dst = cv2.threshold(img,0,255,cv2.THRESH_OTSU)

cv2.imshow("dst",dst)



#edge = dst - dst_erode

#结构元半径
r=1
MAX_R = 20

#显示膨胀效果的窗口
cv2.namedWindow("dilae",cv2.WINDOW_NORMAL)

#定义回调函数
def callback(object):
    pass

cv2.createTrackbar("r","dilate",r, MAX_R,callback)

#得到当前r值
r= cv2.getTrackbarPos("r", "dilate")
#创建结构元
s = cv2.getStructuringElement(cv2.MORPH_ELLIPSE,(2 * r + 1, 2 * r + 1))

#膨胀图像
dst_dilate = cv2.dilate(dst,s)

cv2.imshow("src",img)
cv2.imshow("dst",dst)
cv2.imshow("dst_dilate",dst_dilate)



cv2.waitKey(0)
cv2.destroyAllWindows()
